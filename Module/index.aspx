<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ระบบทุนการศึกษา : Mahidol Scholarship</title>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1.0" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="description" content="Mahidol University, Mahidol Scholarship,ทุนการศึกษา, มหาวิทยาลัยมหิดล" />
    <meta name="author" content="nopparat.jap@mahidol.ac.th/2016(Odd#Nopparat)" />
    <link rel="icon" href="../Content/Image/Logo.png" sizes="32x32" />
    <link href="../Content/jQuery/jquery-ui.css" rel="stylesheet" />
    <link href="../Content/iCheck/skins/all.css" rel="stylesheet" />    
    <link href="//netdna.bootstrapcdn.com/font-awesome/4.0.3/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="../Content/Semantic/dist/semantic.css" rel="stylesheet" />
    <link href="../Content/Semantic/dist/style.css" rel="stylesheet" /> 
    <link href="../Content/Semantic/calendar/dist/calendar.css" rel="stylesheet" />
    <link href="../Content/CSS/StyleSheet.css" rel="stylesheet" />
    <script src="../Content/jQuery/external/jquery/jquery.js"></script>
    <script src="../Content/jQuery/jquery-ui.js"></script>
    <script src="../Content/iCheck/icheck.js"></script>
    <script src="../Content/Semantic/dist/semantic.js"></script>
    <script src="../Content/Semantic/dist/tablesort.js"></script>
    <script src="../Content/Semantic/dist/notify.min.js"></script>
    <script src="../Content/Semantic/highchart/highcharts.js"></script>
    <script src="../Content/Semantic/highchart/modules/exporting.js"></script>
    <script src="../Content/Semantic/calendar/dist/calendar.js"></script>
    <script src="../Content/JScript/BrowserDetect.js"></script>
    <script src="../Content/JScript/SCHUtil.js"></script>
    <script src="../Content/JScript/SCHScholarship.js"></script>
    <script src="../Content/JScript/SCHRegisterScholarship.js"></script>
    <script src="../Content/JScript/SCHManageScholarship.js"></script>
    <script src="../Content/JScript/SCHImportRegisterScholarship.js"></script>
    <script src="../Content/JScript/SCHFinanceScholarship.js"></script>
    <script src="../Content/JScript/SCHReportScholarship.js"></script>
</head>
<body>
    <div id="followingmenu" class='ui large top fixed hidden menu inverted bg-mahidol-blue' runat="server"></div>
    <div id="sidebarmenu" class="ui vertical sidebar menu" runat="server"></div>
    <div id="header" class="ui vertical masthead bg-mahidol-blue hidden" runat="server"></div>          
    <div id="body" class="hidden">
        <div id="main">
            <div class="ui item container" id="userprofile" runat="server"></div>
            <div id="bodycontent"></div>
        </div>
    </div>
    <div id="footer" class="bg-mahidol-blue hidden" runat="server"></div>    
    <div class="hidden" id="page"><% Response.Write(Request.QueryString["p"]); %></div>
    <div class="hidden" id="lang"><% Response.Write(Request.QueryString["lang"]); %></div>
    <div class="hidden" id="id"><% Response.Write(Request["id"]); %></div>
    <!--
    <div class="ui modal small dialogpreloading">        
        <div class="ui large text loader font-en regular black">Loading</div>
    </div>
    -->
    <div class="ui segment dialogpreloading">
        <div class="ui active dimmer">
            <div class="ui large text loader font-en regular black">Loading</div>
        </div>
    </div>
    <div class="ui modal small dialogmessage">
        <div class="content">
            <h4 class="description">
                <span class="lang lang-th f9 font-th regular white message-th"></span>
                <span class="lang lang-en f9 font-en regular white message-en"></span>
            </h4>
        </div>
        <div class="actions">
            <div class="ui button approve">
                <span class="lang lang-th f9 font-th regular white message-th">ตกลง</span>
                <span class="lang lang-en f9 font-en regular white message-en">OK</span>
            </div>
        </div>
    </div>
    <div class="ui modal small dialogconfirm confirm">
        <div class="content">
            <h4 class="description">
                <span class="lang lang-th f9 font-th regular white message-th"></span>
                <span class="lang lang-en f9 font-en regular white message-en"></span>
            </h4>
        </div>
        <div class="actions">
            <div class="ui button btnconfirm cancel">
                <span class="lang lang-th f9 font-th regular white message-th"></span>
                <span class="lang lang-en f9 font-en regular white message-en"></span>
            </div>
            <div class="ui button btnconfirm approve">
                <span class="lang lang-th f9 font-th regular white message-th"></span>
                <span class="lang lang-en f9 font-en regular white message-en"></span>
            </div>
        </div>
    </div>
    <div class="ui modal small dialogform dialogform1">        
        <div class="header">
            <div class="ui two column grid">
                <div class="left floated thirteen wide column">
                    <span class="lang lang-th f9 font-th regular white message-th"></span>
                    <span class="lang lang-en f9 font-en regular white message-en"></span>                    
                </div>
                <div class="right floated right aligned two wide column">
                    <i class="close icon link font-th regular white btnclose" data-option="dialogform1"></i>
                </div>
            </div>
        </div>        
        <div class="content"></div>
    </div>  
</body>
<script type="text/javascript">    
    $(window).resize(function () {
        Util.setBodyLayout();
    });

    $(function () {
        $(".masthead").visibility({
            once: false,
            onBottomPassed: function () {
                $(".fixed.menu").transition("fade in");
            },
            onBottomPassedReverse: function () {
                $(".fixed.menu").transition("fade out");
            }
        });

        $(".ui.sidebar").sidebar("attach events", ".toc.item");

        Util        = SCHUtil;
        Util.tsl    = SCHScholarship;
        Util.trs    = SCHRegisterScholarship;
        Util.tms    = SCHManageScholarship;
        Util.tis    = SCHImportRegisterScholarship;
        Util.tfs    = SCHFinanceScholarship;
        Util.tps    = SCHReportScholarship
        
        Util.initMenu();
        Util.initMain();
        Util.initTextSelect();
        Util.setDialogFormOnClick();
        Util.loadPage(function () { });
    });
</script>
</html>
