#pragma checksum "C:\Users\shira\source\repos\FinalProject\FinalProject\TheGame.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "B84EB94B3764FF5DCEEB2AB56A64001B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FinalProject
{
    partial class TheGame : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // TheGame.xaml line 11
                {
                    global::Windows.UI.Xaml.Controls.Grid element2 = (global::Windows.UI.Xaml.Controls.Grid)(target);
                    ((global::Windows.UI.Xaml.Controls.Grid)element2).KeyDown += this.Canvas_KeyDown;
                }
                break;
            case 3: // TheGame.xaml line 75
                {
                    this.Back = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.Back).Click += this.Back_Click;
                }
                break;
            case 4: // TheGame.xaml line 13
                {
                    this.sp = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 5: // TheGame.xaml line 71
                {
                    this.mainRe = (global::Windows.UI.Xaml.Shapes.Rectangle)(target);
                }
                break;
            case 6: // TheGame.xaml line 72
                {
                    this.ball = (global::Windows.UI.Xaml.Shapes.Ellipse)(target);
                }
                break;
            case 7: // TheGame.xaml line 68
                {
                    this.tb2 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 8: // TheGame.xaml line 69
                {
                    this.tb = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

