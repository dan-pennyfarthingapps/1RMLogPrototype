using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Dialog;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace RMLogPrototype
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the 
	// User Interface of the application, as well as listening (and optionally responding) to 
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
				// class-level declarations
		UIWindow window;
		UINavigationController navigation;
		UIBarButtonItem addbutton;
		DialogViewController rootVC;
		RootElement rootElement;
		ExerciseList exercises;


		//
		// This method is invoked when the application has loaded and is ready to run. In this 
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{


			// create a new window instance based on the screen size
			window = new UIWindow (UIScreen.MainScreen.Bounds);
			
			// If you have defined a view, add it here:
			// window.AddSubview (navigationController.View);
			rootElement = new RootElement ("1RM Log") { new Section () };
			rootVC = new DialogViewController (rootElement);
			navigation = new UINavigationController (rootVC);

			exercises = new ExerciseList ();

			// Test exercises;
			Exercise bp = new Exercise ();
			bp.Name = "bench press";
			bp.LogRM(DateTime.Now, 150.3);
			bp.LogRM(DateTime.Now, 120.1);
			exercises.AddLast (bp);

			Exercise sq = new Exercise ();
			sq.Name = "squat";
			exercises.AddLast (sq);


			// add the existing list to the screen
			foreach (Exercise exer in exercises) {
				var localExer = exer;
				StyledStringElement newExercise = new StyledStringElement (localExer.Name, () => {
					ExerciseLog (localExer); });
				newExercise.Accessory = UITableViewCellAccessory.DisclosureIndicator;


				rootElement [0].Add (newExercise);

			}

			// Add new Exercises to the Log
			addbutton = new UIBarButtonItem (UIBarButtonSystemItem.Add);
			rootVC.NavigationItem.RightBarButtonItem = addbutton;
			int i = 0;

			addbutton.Clicked += (sender, e) => {
				++i;

				Exercise newExerciseToAdd = new Exercise ();
				newExerciseToAdd.Name = "new exercise " + i.ToString();


				// Add element
				StyledStringElement newExercise = new StyledStringElement (newExerciseToAdd.Name, () => {
					ExerciseLog (newExerciseToAdd); });
				newExercise.Accessory = UITableViewCellAccessory.DisclosureIndicator;

				rootElement [0].Add (newExercise);
				exercises.AddLast (newExerciseToAdd);

			};

			// make the window visible
			window.RootViewController = navigation;
			window.MakeKeyAndVisible ();


			
			return true;
		}



		public void ExerciseLog(Exercise exercise)
		{
			Exercise e = exercise;

			RootElement logRoot = new RootElement (e.Name + " log") { };
			Section entries = e.getAllEntries();
			logRoot.Add (entries);
			
			// TODO add the ability to add logs.
			
		

			var dvc = new DialogViewController (logRoot, true);
			navigation.PushViewController (dvc, true);

		}
	}
}

