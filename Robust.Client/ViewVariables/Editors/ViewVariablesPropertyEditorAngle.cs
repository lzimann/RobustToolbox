using System.Globalization;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controls;
using Robust.Shared.Maths;

namespace Robust.Client.ViewVariables.Editors
{
    public class ViewVariablesPropertyEditorAngle : ViewVariablesPropertyEditor
    {
        protected override Control MakeUI(object value)
        {
            var hBox = new HBoxContainer
            {
                CustomMinimumSize = new Vector2(200, 0)
            };
            var angle = (Angle) value;
            var lineEdit = new LineEdit
            {
                Text = angle.Degrees.ToString(CultureInfo.InvariantCulture),
                Editable = !ReadOnly,
                SizeFlagsHorizontal = Control.SizeFlags.FillExpand
            };
            if (!ReadOnly)
            {
                lineEdit.OnTextEntered += e =>
                    ValueChanged(Angle.FromDegrees(double.Parse(e.Text, CultureInfo.InvariantCulture)));
            }

            hBox.AddChild(lineEdit);
            hBox.AddChild(new Label {Text = "deg"});
            return hBox;
        }
    }
}
