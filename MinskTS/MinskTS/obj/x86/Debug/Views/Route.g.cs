﻿#pragma checksum "E:\MyWork\Курсавой проект\MinskTS\MinskTS\Views\Route.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "39A4C12CFA05F5E0C7DC567586B50B79"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MinskTS.Views
{
    partial class Route : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.suggestRoute = (global::Windows.UI.Xaml.Controls.AutoSuggestBox)(target);
                    #line 10 "..\..\..\Views\Route.xaml"
                    ((global::Windows.UI.Xaml.Controls.AutoSuggestBox)this.suggestRoute).TextChanged += this.suggestBox_TextChanged2;
                    #line default
                }
                break;
            case 2:
                {
                    this.scheduleRoute = (global::Windows.UI.Xaml.Controls.ListView)(target);
                    #line 12 "..\..\..\Views\Route.xaml"
                    ((global::Windows.UI.Xaml.Controls.ListView)this.scheduleRoute).ItemClick += this.ScheduleList_ItemClick;
                    #line default
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

