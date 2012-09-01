
using System;
using System.Drawing;
using System.Linq;

using MonoTouch.Dialog;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace RMLogPrototype
{
	public partial class LogScreen : UIViewController
	{

		private Exercise _exercise;
		private RootElement _rootElement;
		private DialogViewController _rootVC;



		public LogScreen (Exercise exercise) : base ("LogScreen", null)
		{
			//this.NavigationController.Title = exercise.Name;
			this._exercise = exercise;
		}
		
		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// Perform any additional setup after loading the view, typically from a nib.
			this._rootElement = new RootElement(this._exercise.Name){ new Section () };
			this._rootVC = new DialogViewController(this._rootElement);


		}
		
		public override void ViewDidUnload ()
		{
			base.ViewDidUnload ();
			
			// Clear any references to subviews of the main view in order to
			// allow the Garbage Collector to collect them sooner.
			//
			// e.g. myOutlet.Dispose (); myOutlet = null;
			
			ReleaseDesignerOutlets ();
		}
		
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
		}
	}
}

