namespace CodeProject
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class GraphicalOverlay : Component
    {
        public event EventHandler<PaintEventArgs> Paint;
        private Form form;

        public GraphicalOverlay()
        {
            InitializeComponent();
        }

        public GraphicalOverlay(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Form Owner
        {
            get { return form; }
            set 
            {
                // The owner form cannot be set to null.
                if (value == null)
                    throw new ArgumentNullException();

                // The owner form can only be set once.
                if (form != null)
                    throw new InvalidOperationException();

                // Save the form for future reference.
                form = value;

                // Handle the form's Resize event.
                form.Resize += new EventHandler(Form_Resize);

                // Handle the Paint event for each of the controls in the form's hierarchy.
                ConnectPaintEventHandlers(form);
            }
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            form.Invalidate(true);
        }

        private void ConnectPaintEventHandlers(Control control)
        {
            // Connect the paint event handler for this control.
            // Remove the existing handler first (if one exists) and replace it.
            control.Paint -= new PaintEventHandler(Control_Paint);
            control.Paint += new PaintEventHandler(Control_Paint);

            control.ControlAdded -= new ControlEventHandler(Control_ControlAdded);
            control.ControlAdded += new ControlEventHandler(Control_ControlAdded);

            // Recurse the hierarchy.
            foreach (Control child in control.Controls)
                ConnectPaintEventHandlers(child);
        }

        private void Control_ControlAdded(object sender, ControlEventArgs e)
        {
            // Connect the paint event handler for the new control.
            ConnectPaintEventHandlers(e.Control);
        }

        private void Control_Paint(object sender, PaintEventArgs e)
        {
            // As each control on the form is repainted, this handler is called.

            Control control = sender as Control;
            Point location;

            // Determine the location of the control's client area relative to the form's client area.
            if (control == form)
                // The form's client area is already form-relative.
                location = control.Location;
            else
            {
                // The control may be in a hierarchy, so convert to screen coordinates and then back to form coordinates.
                location = form.PointToClient(control.Parent.PointToScreen(control.Location));

                // If the control has a border shift the location of the control's client area.
                location += new Size((control.Width - control.ClientSize.Width) / 2, (control.Height - control.ClientSize.Height) / 2);
            }

            // Translate the location so that we can use form-relative coordinates to draw on the control.
            if (control != form)
                e.Graphics.TranslateTransform(-location.X, -location.Y);

            // Fire a paint event.
            OnPaint(sender, e);
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            // Fire a paint event.
            // The paint event will be handled in Form1.graphicalOverlay1_Paint().

            if (Paint != null)
                Paint(sender, e);
        }
    }
}

namespace System.Windows.Forms
{
    using System.Drawing;

    public static class Extensions
    {
        public static Rectangle Coordinates(this Control control)
        {
            // Extend System.Windows.Forms.Control to have a Coordinates property.
            // The Coordinates property contains the control's form-relative location.
            Rectangle coordinates;
            Form form = (Form)control.TopLevelControl;

            if (control == form)
                coordinates = form.ClientRectangle;
            else
                coordinates = form.RectangleToClient(control.Parent.RectangleToScreen(control.Bounds));

            return coordinates;
        }
    }
}
