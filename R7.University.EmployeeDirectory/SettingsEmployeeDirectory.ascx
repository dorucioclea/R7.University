﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SettingsEmployeeDirectory.ascx.cs" Inherits="R7.University.EmployeeDirectory.SettingsEmployeeDirectory" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.Web.UI.WebControls" Assembly="DotNetNuke.Web" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.Web.Client.ClientResourceManagement" Assembly="DotNetNuke.Web.Client" %>

<dnn:DnnCssInclude runat="server" FilePath="~/DesktopModules/R7.University/R7.University.EmployeeDirectory/admin.css" Priority="200" />
<dnn:DnnCssInclude runat="server" FilePath="~/DesktopModules/R7.University/R7.University/css/admin.css" />
<div class="dnnForm dnnClear employee-directory-settings">
    <fieldset>  
        <div class="dnnFormItem">
            <dnn:Label id="labelMode" runat="server" ControlName="comboMode" />
            <asp:DropDownList id="comboMode" runat="server" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label id="labelEduLevels" runat="server" ControlName="listEduLevels" />
            <dnn:DnnListBox id="listEduLevels" runat="server" CheckBoxes="true" CssClass="dnn-form-control" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label id="labelShowAllTeachers" runat="server" ControlName="checkShowAllTeachers" />
            <asp:CheckBox id="checkShowAllTeachers" runat="server" />
        </div>
    </fieldset>
</div>

