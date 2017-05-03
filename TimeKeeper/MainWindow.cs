using System;
using Gtk;
using System.Windows.Forms;
using System.Collections;

public partial class MainWindow: Gtk.Window
{
	Timer timer = new Timer ();
	int interval  = 1;
	ArrayList events = new ArrayList ();
	ListStore listEvents = new ListStore (typeof(int), typeof(int));
	TreeViewColumn colDuration = new TreeViewColumn ();
	TreeViewColumn colInterval = new TreeViewColumn ();

	public MainWindow () : base (Gtk.WindowType.Toplevel)
	{
		Build ();
		label2.Text = "Time selection";
		label2.ModifyFont (Pango.FontDescription.FromString ("Arial 16"));
		label2.ModifyBg (StateType.Normal, new Gdk.Color (0xa0, 0xa0, 0xa0));
		spinbutton4.ModifyFont (Pango.FontDescription.FromString ("Arial 16"));
		spinbutton4.ModifyBg (StateType.Normal, new Gdk.Color (0xa0, 0xa0, 0xa0));
		button1.ModifyFont (Pango.FontDescription.FromString ("Arial 16"));
		button1.ModifyBg (StateType.Normal, new Gdk.Color (0xa0, 0xa0, 0xa0));


		colInterval.Title = "Interval";
		colDuration.Title = "Duration";
		treeview1.AppendColumn (colInterval);
		treeview1.AppendColumn (colDuration);
		treeview1.Model = listEvents;
		treeview1.ModifyBg (StateType.Normal, new Gdk.Color (0xff, 0xff, 0xff));

		this.ModifyBg (StateType.Normal, new Gdk.Color (0x50, 0x50, 0x50));
		timer.Interval = 1000;


	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Gtk.Application.Quit ();
		a.RetVal = true;
	}


	protected void OnButton1Clicked (object sender, EventArgs e)
	{
		listEvents.AppendValues (interval, (int)spinbutton4.Value);
		CellRenderer intervalRender = new CellRendererText ();
		colInterval.PackStart (intervalRender, true);
		CellRenderer durationRender = new CellRendererText ();
		colDuration.PackStart (durationRender, true);

		colInterval.AddAttribute (intervalRender, "int", 0);
		colDuration.AddAttribute (durationRender, "int", 1);
		events.Add (1000 * (int)spinbutton4.Value);

		interval++;
	}
}
