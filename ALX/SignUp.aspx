<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="ALX.Login" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #Text1 {
            width: 248px;
            text-align: center;
            margin-top: 0px;
        }
        #Text2 {
            width: 248px;
            margin-top: 0px;
        }
        .auto-style1 {
            text-align: center;
        }
     
        #Text2 {
            width: 248px;
            text-align: center;
            margin-top: 0px;
        }
        #Text3 {
            width: 248px;
            text-align: center;
            margin-top: 0px;
        }
        #Text4 {
            width: 248px;
            text-align: center;
            margin-top: 0px;
        }
        #form1 {
            text-align: center;
        }
        .auto-style2 {
            text-align: left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1 class="auto-style1" style="font-size: larger">SIGN UP&nbsp; PAGE</h1>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p class="auto-style2">
            USERNAME
            <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" 
                ErrorMessage="Name required" ControlToValidate="TextBox1" ForeColor="Red" Type="string" OnDataBinding="Button1_Click" EnableClientScript="False"></asp:RequiredFieldValidator>
        </p>
        <p style="text-align: left">
            &nbsp;PASSWORD <asp:TextBox ID="TextBox2" runat="server" OnTextChanged="TextBox1_TextChanged" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" runat="server" 
                ErrorMessage="Password required" ControlToValidate="TextBox2" ForeColor="Red" Type="string" OnDataBinding="Button1_Click" EnableClientScript="False"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                ErrorMessage="RegularExpressionValidator" ControlTOValidate="TextBOx2" ForeColor="Red"
                Display="Dynamic" ValidationExpression="[A-Z]+[A-Za-z0-9\W]+\W+[0-9]+[A-Za-z0-9]*"
                runat="server" >

            </asp:RegularExpressionValidator>
        </p>
        <p style="text-align: left">
            &nbsp;CONFIRM PASSWORD <asp:TextBox ID="TextBox5" runat="server" OnTextChanged="TextBox1_TextChanged" TextMode="Password"></asp:TextBox>
            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidatorConfirmPassword" runat="server" 
                ErrorMessage="Password reqired" ControlToValidate="TextBox5" FortColor="Red" Type="string" ForeColor="Red" Display="Dynamic" OnDataBinding="Button1_Click" EnableClientScript="False"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidatorPassword" runat="server"
                 ErrorMessage="Password does not match" FortColor="Red" ControlToValidate="TextBox5" ControlToCompare="TextBox2"
                Operator="Equal" Type="String" Display="Dynamic" ForeColor="Red" OnDataBinding="Button1_Click" EnableClientScript="False"></asp:CompareValidator>
        </p>
        <p class="auto-style2">
            &nbsp;EMAIL&nbsp;<asp:TextBox ID="TextBox3" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" runat="server"
                 ErrorMessage=" Email Required" ControlToValidate="TextBox3" ForeColor="Red" Display="Dynamic" OnDataBinding="Button1_Click" EnableClientScript="False" ></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" runat="server" 
                ErrorMessage="Invalid Email" ControlToValidate="TextBox3" Display="Dynamic"
                 ValidationExpression="[a-zA-Z0-9.-]+@[a-zA-Z0-9]+\.[a-zA-Z0-9]+" ForeColor="Red" OnDataBinding="Button1_Click" EnableClientScript="False"></asp:RegularExpressionValidator>
        </p>
        <p class="auto-style2">
            &nbsp;PHONE NO&nbsp;&nbsp;&nbsp;<asp:TextBox ID="TextBox4" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
            .<asp:RequiredFieldValidator ID="RequiredFieldValidatorPhoneNo" runat="server" 
                ErrorMessage="Phone no required" ControlToValidate="TextBox4"
                ForeColor="Red" Type="Integer" OnDataBinding="Button1_Click" EnableClientScript="False"></asp:RequiredFieldValidator>
            <%--<asp:RangeValidator ID="RangeValidator1" runat="server" 
                ErrorMessage="Invalid Phone No" ControlToValidate="TextBox4"
                MinimumValue="0000000000" MaximumValue="9999999999" Type="Integer" 
                >

            </asp:RangeValidator>--%>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Only 10 digits number are allowed"
              ControlToValidate="TextBox4" ForeColor="Red" ValidationExpression="\d\d\d\d\d\d\d\d\d\d"  > 

            </asp:RegularExpressionValidator>
        </p>
        <p class="auto-style1">
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" style="height: 29px; text-align: center;" Text="SUBMIT" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="LogIN" />
&nbsp;&nbsp;&nbsp;&nbsp;
        </p>
    <p>
        &nbsp;</p>
        <h4 style="text-align: center">&nbsp;</h4>
        <p style="text-align: left">
             &nbsp;</p>
        <p style="text-align: left">
            &nbsp;</p>
        <p>
           
        <p>
            &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
        </p>
    </form>
    </body>
</html>
