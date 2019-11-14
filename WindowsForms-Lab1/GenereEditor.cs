using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForms_Lab1
{
    class GenereEditor : System.Drawing.Design.UITypeEditor
    {
        public override System.Drawing.Design.UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context )
        {
            return System.Drawing.Design.UITypeEditorEditStyle.DropDown;
        }

        public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, System.IServiceProvider provider, object value)
        {
            System.Windows.Forms.Design.IWindowsFormsEditorService edSvc = 
                (System.Windows.Forms.Design.IWindowsFormsEditorService)provider.GetService(typeof(System.Windows.Forms.Design.IWindowsFormsEditorService));
            if (edSvc != null)
            {
                GenerePicker genereEdit = new GenerePicker((Book.BookGenere)value);
                edSvc.DropDownControl(genereEdit);
                return genereEdit.Genere;
            }
            return value;
        }
    }
}
