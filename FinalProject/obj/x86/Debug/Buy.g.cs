﻿#pragma checksum "C:\Users\shira\source\repos\FinalProject\FinalProject\Buy.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "7A44668DD15E62296FE18E5003C42CA2"
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
    partial class Buy : 
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
            case 2: // Buy.xaml line 29
                {
                    this.Buyy = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.Buyy).Click += this.Buy_Click;
                }
                break;
            case 3: // Buy.xaml line 30
                {
                    this.Back = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.Back).Click += this.Back_Click;
                }
                break;
            case 4: // Buy.xaml line 23
                {
                    this.tb2 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 5: // Buy.xaml line 24
                {
                    this.cvv = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 6: // Buy.xaml line 19
                {
                    this.tb5 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 7: // Buy.xaml line 20
                {
                    this.expierd = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 8: // Buy.xaml line 15
                {
                    this.tb1 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 9: // Buy.xaml line 16
                {
                    this.cardNum = (global::Windows.UI.Xaml.Controls.TextBox)(target);
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
