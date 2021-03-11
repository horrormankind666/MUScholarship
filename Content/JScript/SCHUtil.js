var SCHUtil = {
    tsl: "",
    trs: "",
    tms: "",
    tis: "",
    tfs: "",
    time: 120,
    urlHandler: "../Content/Handler/SCHHandler.ashx",
    msgPreloading: "",
    rowPerPage: 100,
    currentPage: 0,
    startRow: 1,
    endRow: 1,    
    lang: "TH",

    subjectMeaningofScholarshipPayType: "MeaningOfScholarshipPayType",
    subjectICL: "ICL",
    subjectStudentCV: "StudentCV",
    subjectScholarship: "Scholarship",
    subjectRegisterScholarship: "RegisterScholarship",
    subjectRegisterScholarshipTemplate: "RegisterScholarshipTemplate",
    subjectRegisterScholarshipStudentCV: "RegisterScholarshipStudentCV",    
    subjectManageScholarship: "ManageScholarship",
    subjectManageScholarshipStudentCV: "ManageScholarshipStudentCV",
    subjectManageScholarshipStudentCancel: "ManageScholarshipStudentCancel",
    subjectManageScholarshipStudentCancelStudentCV: "ManageScholarshipStudentCancelStudentCV",
    subjectManageScholarshipTypeGroupICL: "ManageScholarshipTypeGroupICL",
    subjectImportRegisterScholarship: "ImportRegisterScholarship",
    subjectFinanceScholarshipTypeGroupICL: "FinanceScholarshipTypeGroupICL",
    subjectFinanceScholarshipTypeGroupICLApprovalReceiveFinance: "FinanceScholarshipTypeGroupICLApprovalReceiveFinance",
    subjectFinanceScholarshipTypeGroupICLSavePeopleApproved: "FinanceScholarshipTypeGroupICLSavePeopleApproved",    
    subjectFinanceScholarshipTypeGroupICLClassificationRecipientFinance: "FinanceScholarshipTypeGroupICLClassificationRecipientFinance",
    subjectFinanceScholarshipTypeGroupICLPayCheque: "FinanceScholarshipTypeGroupICLPayCheque",
    subjectFinanceScholarshipTypeGroupICLSavePeoplePayCheque: "FinanceScholarshipTypeGroupICLSavePeoplePayCheque",
    subjectFinanceScholarshipTypeGroupICLStudentCV: "FinanceScholarshipTypeGroupICLStudentCV",
    subjectReportScholarship: "ReportScholarship",
    subjectReportListOfPeopleApprovedFinanceFromICL: "ReportListOfPeopleApprovedFinanceFromICL",
    subjectReportScholarshipStudentCV: "ReportScholarshipStudentCV",
    
    pageMeaningofScholarshipPayTypeMain: "MeaningOfScholarshipPayTypeMain",
    pageMain: "Main",
    pageScholarshipMain: "ScholarshipMain",
    pageScholarshipAdd: "ScholarshipAdd",
    pageScholarshipUpdate: "ScholarshipUpdate",
    pageRegisterScholarshipMain: "RegisterScholarshipMain",
    pageRegisterScholarshipStudentCVMain: "RegisterScholarshipStudentCVMain",
    pageRegisterScholarshipAddUpdate: "RegisterScholarshipAddUpdate",    
    pageManageScholarshipMain: "ManageScholarshipMain",
    pageManageScholarshipStudentCVMain: "ManageScholarshipStudentCVMain",
    pageManageScholarshipStudentCancelMain: "ManageScholarshipStudentCancelMain",
    pageManageScholarshipAddUpdate: "ManageScholarshipAddUpdate",
    pageManageScholarshipStudentCancelAddUpdate: "ManageScholarshipStudentCancelAddUpdate",
    pageManageScholarshipTypeGroupICLAddUpdate: "ManageScholarshipTypeGroupICLAddUpdate",
    pageImportRegisterScholarshipMain: "ImportRegisterScholarshipMain",
    pageImportRegisterScholarshipStudentCVMain: "ImportRegisterScholarshipStudentCVMain",
    pageImportRegisterScholarshipAddUpdate: "ImportRegisterScholarshipAddUpdate",    
    pageFinanceScholarshipMain: "FinanceScholarshipMain",
    pageFinanceScholarshipTypeGroupICLMain: "FinanceScholarshipTypeGroupICLMain",
    pageFinanceScholarshipTypeGroupICLApprovalReceiveFinanceMain: "FinanceScholarshipTypeGroupICLApprovalReceiveFinanceMain",
    pageFinanceScholarshipTypeGroupICLApprovalReceiveFinanceAdd: "FinanceScholarshipTypeGroupICLApprovalReceiveFinanceAdd",
    pageFinanceScholarshipTypeGroupICLApprovalReceiveFinanceUpdate: "FinanceScholarshipTypeGroupICLApprovalReceiveFinanceUpdate",
    pageFinanceScholarshipTypeGroupICLSavePeopleApprovedMain: "FinanceScholarshipTypeGroupICLSavePeopleApprovedMain",
    pageFinanceScholarshipTypeGroupICLSavePeopleApprovedAddUpdate: "FinanceScholarshipTypeGroupICLSavePeopleApprovedAddUpdate",    
    pageFinanceScholarshipTypeGroupICLClassificationRecipientFinanceMain: "FinanceScholarshipTypeGroupICLClassificationRecipientFinanceMain",
    pageFinanceScholarshipTypeGroupICLClassificationRecipientFinanceAddUpdate: "FinanceScholarshipTypeGroupICLClassificationRecipientFinanceAddUpdate",
    pageFinanceScholarshipTypeGroupICLPayChequeMain: "FinanceScholarshipTypeGroupICLPayChequeMain",
    pageFinanceScholarshipTypeGroupICLPayChequeAdd: "FinanceScholarshipTypeGroupICLPayChequeAdd",
    pageFinanceScholarshipTypeGroupICLPayChequeUpdate: "FinanceScholarshipTypeGroupICLPayChequeUpdate",
    pageFinanceScholarshipTypeGroupICLSavePeoplePayChequeMain: "FinanceScholarshipTypeGroupICLSavePeoplePayChequeMain",
    pageFinanceScholarshipTypeGroupICLSavePeoplePayChequeAddUpdate: "FinanceScholarshipTypeGroupICLSavePeoplePayChequeAddUpdate",
    pageFinanceScholarshipTypeGroupICLStudentCVMain: "FinanceScholarshipTypeGroupICLStudentCVMain",
    pageReportScholarshipMain: "ReportScholarshipMain",
    pageReportListOfPeopleApprovedFinanceFromICLMain: "ReportListOfPeopleApprovedFinanceFromICLMain",
    pageReportListOfPeopleApprovedFinanceFromICLExport: "ReportListOfPeopleApprovedFinanceFromICLExport",
    pageReportScholarshipStudentCVMain: "ReportScholarshipStudentCVMain",

    loadAjax: function (_param, _callBackFunc) {
        _param.url                  = (_param.url == undefined ? "" : _param.url);
        _param.method               = (_param.method == undefined ? "" : _param.method);
        _param.data                 = (_param.data == undefined || _param.data == "" ? {} : _param.data);
        _param.showPreloadingInline = (_param.showPreloadingInline == undefined || _param.showPreloadingInline == "" ? false : _param.showPreloadingInline);
        _param.idPreloadingInline   = (_param.idPreloadingInline == undefined ? "" : _param.idPreloadingInline);

        var _this = this;

        $.ajax({
            beforeSend: function () {
                if (_this.msgPreloading.length > 0 && _param.showPreloadingInline == false) _this.dialogPreloading();
                if (_param.showPreloadingInline == true) $("#" + _param.idPreloadingInline).html("<img class='preloading-inline' src='../Content/Image/PerloadingInline.gif' />");
            },            
            async: true,
            type: _param.method,
            url: _param.url,
            data: _param.data,
            dataType: "json",
            charset: "utf-8",
            success: function (_result) {
                if (_this.msgPreloading.length > 0 && _param.showPreloadingInline == false)
                    $(".dialogpreloading").modal("hide");
                if (_param.showPreloadingInline == true)
                    $("#" + _param.idPreloadingInline).html("");
                
                if (BrowserDetect.browser == "Explorer" && BrowserDetect.version < 10)
                {
                    $(".dialogpreloading").hide();
                    alert("ไม่สนับสนุน IE ต่ำกว่าเวอร์ชั้น 10\nNot support IE ​​less than version 10.");
                    /*
                    _this.dialogMessage({
                        type: "danger",
                        msgTH: "ไม่สนับสนุน IE ต่ำกว่าเวอร์ชั้น 10 <a href='http://windows.microsoft.com/en-us/internet-explorer/download-ie' target='_blank'>( คลิกเพื่อดาวน์โหลด IE เวอร์ชั่นใหม่ )</a>",
                        msgEN: "Not support IE ​​less than version 10. <a href='http://windows.microsoft.com/en-us/internet-explorer/download-ie' target='_blank'>( Click to download the latest version of Internet Explorer. )</a>"
                    }, function (_result) { });
                    */
                    return;
                }
                
                _callBackFunc(_result);
            },
            error: function (_xhr, _ajaxOptions, _thrownError) {
                //alert(_xhr.responseText);
                $(".dialogpreloading").modal("hide");
                
                _this.setLanguage({});
                $("#header, #body, #footer").removeClass("hidden")

                _this.dialogMessage({
                    type: "danger",
                    msgTH: "ประมวลผลไม่สำเร็จ กรุณารีเฟรชหน้าจอ หรือเปลี่ยนเว็บเบราว์เซอร์",
                    msgEN: "Processing was not successful, Please refresh this page or change web browser."
                }, function (_result) { });
            }
        });
    },

    ajaxUploadFile: function (_param, _callBackFunc) {
        _param.url                  = (_param.url == undefined ? "" : _param.url);
        _param.method               = (_param.method == undefined ? "" : _param.method);
        _param.data                 = (_param.data == undefined ? "" : _param.data);
        _param.showPreloadingInline = (_param.showPreloadingInline == undefined || _param.showPreloadingInline == "" ? false : _param.showPreloadingInline);
        _param.idPreloadingInline   = (_param.idPreloadingInline == undefined ? "" : _param.idPreloadingInline);

        var _this = this;

        $.ajax({
            beforeSend: function () {
                if (_this.msgPreloading.length > 0 && _param.showPreloadingInline == false) _this.dialogPreloading();
                if (_param.showPreloadingInline == true) $("#" + _param.idPreloadingInline).html("<img class='preloading-inline' src='../Content/Image/PerloadingInline.gif' />");
            },            
            async: true,
            type: _param.method,
            url: _param.url,
            data: _param.data,
            charset: "utf-8",
            cache: false,
            processData: false,
            contentType: false,
            enctype: "multipart/form-data",
            success: function (_result) {
                if (_this.msgPreloading.length > 0 && _param.showPreloadingInline == false)
                    $(".dialogpreloading").modal("hide");
                if (_param.showPreloadingInline == true)
                    $("#" + _param.idPreloadingInline).html("");

                _callBackFunc(_result);
            },
            error: function (_xhr, _ajaxOptions, _thrownError) {
                alert(_xhr.responseText);
                $(".dialogpreloading").modal("hide");
                
                _this.setLanguage({});
                $("#header, #body, #footer").removeClass("hidden")

                _this.dialogMessage({
                    type: "danger",
                    msgTH: "ประมวลผลไม่สำเร็จ กรุณารีเฟรชหน้าจอ หรือเปลี่ยนเว็บเบราว์เซอร์",
                    msgEN: "Processing was not successful, Please refresh this page or change web browser."
                }, function (_result) { });
            }
        });
    },

    gotoTopElement: function () {
        $("html, body").animate({
            scrollTop: 0
        }, 0);
    },

    gotoElement: function (_param) {
        _param.anchorName   = (_param.anchorName == undefined ? "" : _param.anchorName);
        _param.inputName    = (_param.inputName == undefined ? "" : _param.inputName);
        _param.top          = (_param.top == undefined ? 0 : _param.top);

        var _anchor = $(_param.anchorName);
        var _input  = $(_param.inputName);
        var _offset = _anchor.offset();     
        
        if (_param.anchorName.length > 0 && _anchor.length > 0)
        {
            $("html, body").animate({
                scrollTop: ((_offset.top) - _param.top)
            }, 500);
        }
    },

    gotoPage: function (_param) {
        _param.page     = (_param.page == undefined ? "" : _param.page);
        _param.target   = (_param.target == undefined || _param.target == "" ? "_top" : _param.target);

        var _w

        if (_param.page.length > 0)
        {            
            try
            {
                _w = window.open(_param.page, _param.target);
            }
            catch(_error)
            {
                _w = window.open(_page, "_top");
            }
        }

        return _w;
    },

    gotoNavPage: function (_param) {
        _param.page         = (_param.page == undefined ? "" : _param.page);
        _param.currentPage  = (_param.currentPage == undefined ? 1 : _param.currentPage);
        _param.startRow     = (_param.startRow == undefined ? 1 : _param.startRow);
        _param.endRow       = (_param.endRow == undefined ? Util.rowPerPage : (_param.endRow == 1 ? Util.rowPerPage : _param.endRow));

        var _this1 = this;
        var _this2;
        var _idGoto;
        var _paramSearch = {};
        var _data = {};

        _this1.currentPage  = _param.currentPage;
        _this1.startRow     = _param.startRow;
        _this1.endRow       = _param.endRow;
        
        if (_param.page == _this1.pageRegisterScholarshipMain)                                          { _this2 = Util.trs; _idGoto = _this2.list.idContent; }
        if (_param.page == _this1.pageManageScholarshipMain)                                            { _this2 = Util.tms; _idGoto = _this2.list.idContent; }
        if (_param.page == _this1.pageManageScholarshipStudentCancelMain)                               { _this2 = Util.tms.studentCancel;  _idGoto = _this2.main.idContent; }
        if (_param.page == _this1.pageFinanceScholarshipTypeGroupICLApprovalReceiveFinanceMain)         { _this2 = Util.tfs.ICL.approvalReceiveFinance; _idGoto = _this2.list.idContent; }
        if (_param.page == _this1.pageFinanceScholarshipTypeGroupICLSavePeopleApprovedMain)             { _this2 = Util.tfs.ICL.savePeopleApproved; _idGoto = _this2.list.idContent; }
        if (_param.page == _this1.pageFinanceScholarshipTypeGroupICLClassificationRecipientFinanceMain) { _this2 = Util.tfs.ICL.classificationRecipientFinance; _idGoto = _this2.list.idContent; }
        if (_param.page == _this1.pageFinanceScholarshipTypeGroupICLPayChequeMain)                      { _this2 = Util.tfs.ICL.payCheque; _idGoto = _this2.list.idContent; }
        if (_param.page == _this1.pageFinanceScholarshipTypeGroupICLSavePeoplePayChequeMain)            { _this2 = Util.tfs.ICL.savePeoplePayCheque; _idGoto = _this2.list.idContent; }
        if (_param.page == _this1.pageReportListOfPeopleApprovedFinanceFromICLMain)                     { _this2 = Util.tps.listOfPeopleApprovedFinanceFromICL; _idGoto = _this2.list.idContent; }

        _data               = _this2.search.value();
        _data.currentPage   = _param.currentPage;
        _data.startRow      = _param.startRow;
        _data.endRow        = _param.endRow;
        
        _this1.msgPreloading = "Loading...";

        _this1.actionTask({
            action: "search",
            page: _param.page,
            data: _data
        }, function (_result) {
            $("#" + _this2.list.idContent).html(_result.List);
            $("#" + _this2.list.idContent + " .recordcountprimary-search").html(_result.RecordCountPrimary);
            if ($("#" + _this2.list.idContent + " .sum-search").length > 0) $("#" + _this2.list.idContent + " .sum-search").html(_result.Sum);
            if ($("#" + _this2.list.idContent + " .table-navpage").length > 0) $("#" + _this2.list.idContent + " .table-navpage").html(_result.NavPage);
            
            _this1.setBodyLayout();
            _this1.setLanguageOnForm({
                id: ("#" + _idGoto)
            });

            _this2.list.init();

            _this1.gotoElement({
                anchorName: ("#" + _idGoto),
                top: ($("#followingmenu").outerHeight())
            });
        });
    },

    dialogClose: function () {
        if ($(".dialogmessage").is(":visible")) $(".dialogmessage").modal("hide");
        if ($(".dialogconfirm").is(":visible")) $(".dialogconfirm").modal("hide");
    },

    dialogPreloading: function () {
        var _this = this;

        _this.dialogClose()

        $(".dialogpreloading .text.loader").html(this.msgPreloading);
        $(".dialogpreloading").modal("setting", {
            closable: false,
            duration: 0,
            allowMultiple: true,
            onShow: function () {
                $(this).css({
                    "margin": "0px",
                    "position": "fixed",
                    "top": "0",
                    "bottom": "0",
                    "left": "0",
                    "right": "0",
                    "width": "auto",                    
                    "background": "transparent",
                    "border": "none",
                    "z-index": "3000"
                });
            }
        }).modal("show");
    },

    dialogMessage: function (_param, _callBackFunc) {
        _param.type     = (_param.type == undefined ? "" : _param.type);
        _param.msgTH    = (_param.msgTH == undefined ? "" : _param.msgTH);
        _param.msgEN    = (_param.msgEN == undefined ? "" : _param.msgEN);

        var _this = this;

        _this.dialogClose();

        $(".dialogmessage").addClass(_param.type);
        $(".dialogmessage." + _param.type + " .actions .button").addClass("btn" + _param.type);
        $(".dialogmessage .content .message-th").html(_param.msgTH);
        $(".dialogmessage .content .message-en").html(_param.msgEN);
        $(".dialogmessage").modal("setting", {
            closable: false,
            detachable: true,
            duration: 0,            
            allowMultiple: true,
            onHidden: function () {
                $(".dialogmessage." + _param.type + " .actions .button").removeClass("btn" + _param.type);
                $(".dialogmessage").removeClass(_param.type);
            },
            onApprove: function () {
                _callBackFunc("Y");
            },
        }).modal("show");

        _this.setLanguageOnForm({
            id: ".dialogmessage"
        });        
    },

    dialogListMessageError: function (_param) {
        _param.content = (_param.content == undefined ? "" : _param.content);

        var _this = this;
        var _i;
        var _msgArray;
        var _contentTH = "";
        var _contentEN = "";
        var _outerHeight = 0;
        var _callFunc;

        if (_param.content.length > 0)
        {
            _contentTH  += "<div class='info-list'>" +
                           "   <ul>";

            for (_i = 0; (_i < _param.content.length && _i < 5) ; _i++)
            {
                _msgArray   = _param.content[_i].split(";");
                _contentTH += "     <li>" + _msgArray[0] + "</li>";
            }

            _contentTH  += "    </ul>" +
                           "</div>";

            _contentEN  += "<div class='info-list'>" +
                           "   <ul>";

            for (_i = 0; (_i < _param.content.length && _i < 5) ; _i++)
            {
                _msgArray   = _param.content[_i].split(";");
                _contentEN += "     <li>" + _msgArray[1] + "</li>";
            }

            _contentTH  += "    </ul>" +
                           "</div>";

            _this.dialogMessage({
                type: "danger",
                msgTH: _contentTH,
                msgEN: _contentEN
            }, function (_result) { });
        }
    },

    dialogConfirm: function (_param, _callBackFunc) {
        _param.msgTH                = (_param.msgTH == undefined ? "" : _param.msgTH);
        _param.msgEN                = (_param.msgEN == undefined ? "" : _param.msgEN);
        _param.msgButtonCancelTH    = (_param.msgButtonCancelTH == undefined ? "" : _param.msgButtonCancelTH);
        _param.msgButtonCancelEN    = (_param.msgButtonCancelEN == undefined ? "" : _param.msgButtonCancelEN);
        _param.msgButtonOKTH        = (_param.msgButtonOKTH == undefined ? "" : _param.msgButtonOKTH);
        _param.msgButtonOKEN        = (_param.msgButtonOKEN == undefined ? "" : _param.msgButtonOKEN);

        var _this = this;

        _this.dialogClose();

        $(".dialogconfirm .content .message-th").html(_param.msgTH);
        $(".dialogconfirm .content .message-en").html(_param.msgEN);
        $(".dialogconfirm .button.cancel .message-th").html(_param.msgButtonCancelTH);
        $(".dialogconfirm .button.cancel .message-en").html(_param.msgButtonCancelEN);
        $(".dialogconfirm .button.approve .message-th").html(_param.msgButtonOKTH);
        $(".dialogconfirm .button.approve .message-en").html(_param.msgButtonOKEN);
        $(".dialogconfirm").modal("setting", {
            closable: false,
            duration: 0,
            allowMultiple: true,
            onDeny: function () {
                _callBackFunc("N");
            },
            onApprove: function () {
                _callBackFunc("Y");
            },
        }).modal("show");

        _this.setLanguageOnForm({
            id: ".dialogconfirm"
        });
    },

    dialogForm: function (_param, _callBackFunc) {
        _param.order    = (_param.order == undefined || _param.order == "" ? "1" : _param.order);
        _param.titleTH  = (_param.titleTH == undefined ? "" : _param.titleTH);
        _param.titleEN  = (_param.titleEN == undefined ? "" : _param.titleEN);
        _param.content  = (_param.content == undefined ? "" : _param.content);
        _param.autoShow = (_param.autoShow == undefined ? true : _param.autoShow);

        var _this = this;

        _this.dialogClose();
        
        $(".dialogform" + _param.order + " .header .message-th").html(_param.titleTH);
        $(".dialogform" + _param.order + " .header .message-en").html(_param.titleEN);
        $(".dialogform" + _param.order + " .content").html(_param.content);
        $(".dialogform" + _param.order).modal("setting", {
            closable: false,
            detachable: true,
            duration: 0,
            autofocus: false,
            allowMultiple: true
        });

        if (_param.autoShow == true) $(".dialogform" + _param.order).modal("show");
        
        if (_param.order == "2")
        {
            $(".dialogform1").dimmer({
                closable: false
            }).dimmer("show");
        }

        _this.setLanguageOnForm({
            id: (".dialogform" + _param.order)
        });

        _callBackFunc();
    },

    blockNonEnglish: function (_obj, _e) {
        var _key;
        var _isCtrl = false;
        var _keychar;
        var _reg;

        if (window.event)
        {
            _key    = _e.keyCode;
            _isCtrl = window.event.ctrlKey
        }
        else
        {
            if (_e.which)
            {
                _key    = _e.which;
                _isCtrl = _e.ctrlKey;
            }
        }

        if (isNaN(_key)) return true;

        _keychar = String.fromCharCode(_key);

        if (_key == 8 || _isCtrl) return true;

        _reg = /^[A-Za-z .-]$/;

        return _reg.test(_keychar);
    },

    blockNonEnglishAndNumeric: function (_obj, _e) {
        var _key;
        var _isCtrl = false;
        var _keychar;
        var _reg;

        if (window.event)
        {
            _key    = _e.keyCode;
            _isCtrl = window.event.ctrlKey
        }
        else
        {
            if (_e.which)
            {
                _key    = _e.which;
                _isCtrl = _e.ctrlKey;
            }
        }

        if (isNaN(_key)) return true;

        _keychar = String.fromCharCode(_key);

        if (_key == 8 || _isCtrl) return true;

        _reg = /^[A-Za-z0-9-\/?\(\) ]$/;

        return _reg.test(_keychar);
    },

    blockEnglish: function (_obj, _e) {
        var _key;
        var _isCtrl = false;
        var _keychar;
        var _reg;

        if (window.event)
        {
            _key    = _e.keyCode;
            _isCtrl = window.event.ctrlKey
        }
        else
        {
            if (_e.which)
            {
                _key    = _e.which;
                _isCtrl = _e.ctrlKey;
            }
        }

        if (isNaN(_key)) return true;

        _keychar = String.fromCharCode(_key);

        if (_key == 8 || _isCtrl) return true;

        _reg = /^[A-Za-z]$/;

        return (_reg.test(_keychar) ? false : true);
    },

    textboxDisable: function (_id) {
        $(_id).prop("disabled", true);
        $(_id).css({
            background: "#CCCCCC",
            color: "#000000"
        });

        $("input:text, input:password, textarea").trigger("blur");
    },

    textboxEnable: function (_id) {
        $(_id).prop("disabled", false);
        $(_id).css({
            background: "#FFFFFF",
            color: "#000000"
        });
    },

    actionTask: function (_param, _callBackFunc) {
        _param.action   = (_param.action == undefined ? "" : _param.action);
        _param.page     = (_param.page == undefined ? "" : _param.page);
        _param.data     = (_param.data == undefined || _param.data == "" ? {} : _param.data);

        var _this = this;
        var _data = _param.data;
        _data.action    = _param.action;
        _data.page      = _param.page;

        _this.loadAjax({
            url: _this.urlHandler,
            method: "POST",
            data: _data
        }, function (_result) {
            _callBackFunc(_result);
        });
    },

    setBodyLayout: function () {
        //var _hRemain = ($(window).height() - ($("#header").outerHeight() + $("#main").outerHeight()) - ($("#bodycontent").html().length > 0 ? ($("#bodycontent").outerHeight()) : 0));
        var _hRemain = ($(window).height() - ($("#header").outerHeight() + $("#main").outerHeight()));

        $("#body").css({
            "height": "auto"
        });
        
        if (_hRemain > $("#footer").outerHeight())
        {            
            $("#body").css({
                "height": (($(window).height() - $("#header").outerHeight() - $("#footer").outerHeight()) + "px")
            });
        }
    },

    clearPage: function () {
        $("#followingmenu .menu .button-bar, " +
          "#sidebarmenu .menu .button-bar, " +
          "#header .button-bar").removeClass("active");
        $("#main-quicksearch").val("");
        $("#body #bodycontent").html("");
    },

    getErrorMsg: function (_param) {
        _param.signinYN     = (_param.signinYN == undefined || _param.signinYN == "" ? "N" : _param.signinYN);
        _param.pageError    = (_param.pageError == undefined || _param.pageError == "" ? 0 : _param.pageError);
        _param.cookieError  = (_param.cookieError == undefined || _param.cookieError == "" ? 0 : _param.cookieError);
        _param.userError    = (_param.userError == undefined || _param.userError == "" ? 0 : _param.userError);
        _param.saveError    = (_param.saveError == undefined || _param.saveError == "" ? 0 : _param.saveError);

        var _this = this;
        var _error = false;
        var _msgTH = "";
        var _msgEN = "";
        var _status = (_param.signinYN + _param.cookieError + _param.userError + _param.saveError);
        
        if (_error == false && _param.pageError == 1)   { _error = true; _msgTH = "ไม่พบหน้านี้"; _msgEN = "Page not found."; }
        if (_error == false && _status == "Y100")       { _error = true; _msgTH = "กรุณาเข้าระบบ"; _msgEN = "Please sign in."; }
        if (_error == false && _status == "Y010")       { _error = true; _msgTH = "ไม่พบสิทธิ์ผู้ใช้งาน"; _msgEN = "No permission user."; }
        if (_error == false && _status == "Y020")       { _error = true; _msgTH = "ไม่พบข้อมูล"; _msgEN = "Data not found."; }
        if (_error == false && _status == "Y001")       { _error = true; _msgTH = "บันทึกข้อมูลไม่สำเร็จ"; _msgEN = "Save was not successful."; }
        if (_error == false && _status == "Y002")       { _error = true; _msgTH = "นำเข้าไฟล์ไม่สำเร็จ"; _msgEN = "File import was not successful."; }
        if (_error == false && _status == "Y003")       { _error = true; _msgTH = "ไม่พบข้อมูลในไฟล์"; _msgEN = "Data not found."; }
        if (_error == false && _status == "Y004")       { _error = true; _msgTH = "ข้อมูลในไฟล์ไม่ถูกต้อง"; _msgEN = "Data in file is invalid."; }
        if (_error == false && _status == "Y005")       { _error = true; _msgTH = "ข้อมูลนี้มีอยู่แล้ว"; _msgEN = "Data is Duplicate."; }

        if (_error == true && _msgTH.length > 0 && _msgEN.length > 0)
            _this.dialogMessage({
                type: "danger",
                msgTH: _msgTH,
                msgEN: _msgEN
            }, function (_result) {
            });

        return _error;
    },

    loadPage: function (_callBackFunc) {
        var _this = this;
        var _error;
        var _page = ($("#page").html().length > 0 ? $("#page").html() : _this.pageMain);
        var _lang = $("#lang").html();
        var _data = {};
        _data.action = "page";
        _data.page   = _page;
        _data.id     = $("#id").html();

        _this.clearPage();        
        _this.setBodyLayout();

        _this.msgPreloading = "Loading...";
        
        _this.loadAjax({
            url: _this.urlHandler,
            method: "POST",
            data: _data,
            showPreloadingInline: false,
        }, function (_result) {
            _page = _result.Page;
            $("#page").html(_result.Page);

            _this.setLanguage({
                lang: _lang
            });
            $("#header, #body, #footer").removeClass("hidden")
            $("#userprofile .quick-search").addClass("hide");

            _error = _this.getErrorMsg({
                        signinYN: _result.SignInYN,
                        pageError: _result.PageError,
                        cookieError: _result.CookieError,
                        userError: _result.UserError
                     });
           
            if (_error == false)
            {                
                if (_result.MainContent.length > 0)
                    $("#body #bodycontent").html(_result.MainContent);

                _this.setLanguage({
                    lang: _lang
                });

                /*
								if (_page == _this.pageMain)
								{
									var _label = "ขอรบกวนผู้ใช้งานทุกท่านตอบ <a href='https://docs.google.com/forms/d/e/1FAIpQLSdIfvO7b-9vW9yVWkuUIx7IiYUhlzEyTmEBdMq-_kkoAP_qNQ/viewform?usp=pp_url&entry.1320515055=%E0%B8%A3%E0%B8%B0%E0%B8%9A%E0%B8%9A%E0%B8%97%E0%B8%B8%E0%B8%99%E0%B8%81%E0%B8%B2%E0%B8%A3%E0%B8%A8%E0%B8%B6%E0%B8%81%E0%B8%A9%E0%B8%B2' target='_blank' style='text-decoration: underline; color: #000000'>แบบประเมินความพึ่งพอใจในการใช้งาน</a> เพื่อไปปรับปรุงระบบให้ดียิ่ง<div style='text-align: right; margin-top: 15px'>ขอขอบคุณผู้ใช้งานทุกท่าน<br />ผู้พัฒนาระบบ</div>";

										_this.dialogMessage({
												type: "info",
												msgTH: _label,
												msgEN: _label
										}, function () { });
								}
                */

                if (_page != _this.pageMain &&
                    _page != _this.pageImportRegisterScholarshipMain &&
                    _page != _this.pageFinanceScholarshipTypeGroupICLMain &&
                    _page != _this.pageReportScholarshipMain)
                    $("#main-quicksearch").removeClass("hide");

                if (_page == _this.pageScholarshipMain)
                    Util.tsl.main.init();
                if (_page == _this.pageRegisterScholarshipMain)
                {
                    $("body").css("min-width", "400px");
                    Util.trs.main.init();
                }
                if (_page == _this.pageManageScholarshipMain)
                {
                    $("body").css("min-width", "420px");
                    Util.tms.main.init();
                }
                if (_page == _this.pageImportRegisterScholarshipMain)
                {
                    $("body").css("min-width", "404px");
                    Util.tis.main.init();
                }
                if (_page == _this.pageFinanceScholarshipTypeGroupICLMain)
                    Util.tfs.ICL.main.init();
                if (_page == _this.pageReportScholarshipMain)
                {
                    $("body").css("min-width", "548px");
                    Util.tps.main.init();
                }
            }   
            _this.setMenu({
                pageError: _result.PageError,
                cookieError: _result.CookieError,
                userError: _result.UserError,
                userLevel: _result.Userlevel,
                userFaculty: _result.Userfaculty,
                menuActive: _result.MenuActiveContent
            });
            _this.setBodyLayout();
            _this.setLanguage({
                lang: _lang
            });

            _this.initTextSelect();

            _this.gotoTopElement();
           
            _callBackFunc();            
        });
    },

    loadForm: function (_param, _callBackFunc) {
        _param.order                = (_param.order == undefined || _param.order == "" ? "1" : _param.order);
        _param.name                 = (_param.name == undefined ? "" : _param.name);
        _param.dialog               = (_param.dialog == undefined || _param.dialog == "" ? false : _param.dialog);
        _param.autoShow             = (_param.autoShow == undefined ? true : _param.autoShow);
        _param.data                 = (_param.data == undefined ? "" : _param.data);
        _param.showPreloadingInline = (_param.showPreloadingInline == undefined || _param.showPreloadingInline == "" ? false : _param.showPreloadingInline);
        _param.idPreloadingInline   = (_param.idPreloadingInline == undefined ? "" : _param.idPreloadingInline);
        _param.id                   = (_param.id == undefined ? "" : _param.id);
        _param.idActive             = (_param.idActive == undefined ? "" : _param.idActive);

        var _this = this;
        var _error;
        var _data = {};
        _data.action = "form";
        _data.form   = _param.name;
        _data.id     = _param.data;
        
        _this.msgPreloading = "Loading...";

        _this.loadAjax({
            url: _this.urlHandler,
            method: "POST",
            data: _data,
            showPreloadingInline: _param.showPreloadingInline,
            idPreloadingInline: _param.idPreloadingInline,
        }, function (_result) {            

            _error = _this.getErrorMsg({
                        signinYN: _result.SignInYN,
                        pageError: _result.FormError,
                        cookieError: _result.CookieError,
                        userError: _result.UserError
                     });
            if (_error == false)
            {                
                if (_result.MainContent.length == 0)
                {
                    _this.dialogMessage({
                        type: "danger",
                        msgTH: "ไม่พบเนื้อหา",
                        msgEN: "Content not found."
                    }, function (_result) { });

                    _callBackFunc(_result);
                }
                else
                    {
                        if (_param.dialog == true)
                        {                            
                            Util.dialogForm({
                                order: _param.order,
                                titleTH: _result.TitleTHContent,
                                titleEN: _result.TitleENContent,
                                content: _result.MainContent,
                                autoShow: _param.autoShow
                            }, function () {
                                _this.initTextSelect();

                                _callBackFunc(_result, "");
                            });
                        }
                        else
                            {                          
                                $(_param.id).html(_result.MainContent);

                                _this.setBodyLayout();
                                _this.setLanguageOnForm({
                                    id: _param.id
                                });

                                _this.initTextSelect();

                                _callBackFunc(_result);
                            }
                    }                
            }
            else
                _callBackFunc(_result);
        });
    },
    
    loadDropdown: function (_param, _callBackFunc) {
        _param.cmd              = (_param.cmd == undefined ? "" : _param.cmd)
        _param.id               = (_param.id == undefined ? "" : _param.id)
        _param.idContainer      = (_param.idContainer == undefined ? "" : _param.idContainer);
        _param.data             = (_param.data == undefined || _param.data == "" ? {} : _param.data);

        var _this = this;
        var _data = _param.data;
        _data.action    = "dropdown";
        _data.cmd       = _param.cmd;
        _data.id        = _param.id

        _this.msgPreloading = "";

        _this.loadAjax({
            url: _this.urlHandler,
            method: "POST",
            data: _data,
            showPreloadingInline: true,
            idPreloadingInline: _param.idContainer,
        }, function (_result) {
            $("#" + _param.idContainer).html(_result.Content);
            
            _this.setLanguageOnForm({
                id: ("#" + _param.idContainer)
            });

            _this.initDropdown({
                id: ("#" + _param.idContainer),
            }, function (_result) {
            });

            _callBackFunc();
        });
    },

    setMenu: function (_param) {
        _param.pageError    = (_param.pageError == undefined || _param.pageError == "" ? 0 : _param.pageError);
        _param.cookieError  = (_param.cookieError == undefined || _param.cookieError == "" ? 0 : _param.cookieError);
        _param.userError    = (_param.userError == undefined || _param.userError == "" ? 0 : _param.userError);
        _param.userLevel    = (_param.userLevel == undefined || _param.userLevel == "" ? 0 : _param.userLevel);
        _param.userFaculty  = (_param.userFaculty == undefined || _param.userFaculty == "" ? 0 : _param.userFaculty);        
        _param.menuActive   = (_param.menuActive == undefined ? "" : _param.menuActive);

        var _idHeaderMenu = "header";
        var _idFollowingMenu = "followingmenu";
        var _idSidebarMenu = "sidebarmenu";
        var _classMenu = "menu";

        if (_param.pageError == 0 && _param.cookieError == 0 && _param.userError == 0)
        {
            _param.userFaculty = _param.userFaculty.substring(0, 2);

            if (_param.userLevel == "ADMIN" && _param.userFaculty == "MU")
            {
                $("#" + _idHeaderMenu + " ." + _classMenu + " .btnscholarship, " +
                  "#" + _idHeaderMenu + " ." + _classMenu + " .btnregisterscholarship, " +
                  "#" + _idHeaderMenu + " ." + _classMenu + " .btnmanagescholarship, " +
                  "#" + _idHeaderMenu + " ." + _classMenu + " .btnimportregisterscholarship, " +                  
                  "#" + _idHeaderMenu + " ." + _classMenu + " .btnfinancescholarshiptypegroupicl, " +
                  "#" + _idHeaderMenu + " ." + _classMenu + " .btnreportscholarship, " +
                  "#" + _idHeaderMenu + " ." + _classMenu + " .btnpermission, " +
                  "#" + _idFollowingMenu + " ." + _classMenu + " .btnscholarship, " +
                  "#" + _idFollowingMenu + " ." + _classMenu + " .btnregisterscholarship, " +
                  "#" + _idFollowingMenu + " ." + _classMenu + " .btnmanagescholarship, " +
                  "#" + _idFollowingMenu + " ." + _classMenu + " .btnimportregisterscholarship, " +                  
                  "#" + _idFollowingMenu + " ." + _classMenu + " .btnfinancescholarshiptypegroupicl, " +
                  "#" + _idFollowingMenu + " ." + _classMenu + " .btnreportscholarship, " +
                  "#" + _idFollowingMenu + " ." + _classMenu + " .btnpermission, " +
                  "#" + _idSidebarMenu + " .btnscholarship, " +
                  "#" + _idSidebarMenu + " .btnregisterscholarship, " +
                  "#" + _idSidebarMenu + " .btnmanagescholarship, " +
                  "#" + _idSidebarMenu + " .btnimportregisterscholarship," +                  
                  "#" + _idSidebarMenu + " .btnfinancescholarshiptypegroupicl, " +
                  "#" + _idSidebarMenu + " .btnreportscholarship, " +
                  "#" + _idSidebarMenu + " .btnpermission").removeClass("hide");
            }

            if (_param.userLevel == "ADMINUSER" && _param.userFaculty == "MU")
            {
                $("#" + _idHeaderMenu + " ." + _classMenu + " .btnscholarship, " +
                  "#" + _idHeaderMenu + " ." + _classMenu + " .btnregisterscholarship, " +
                  "#" + _idHeaderMenu + " ." + _classMenu + " .btnmanagescholarship, " +
                  "#" + _idHeaderMenu + " ." + _classMenu + " .btnimportregisterscholarship, " +
                  "#" + _idHeaderMenu + " ." + _classMenu + " .btnreportscholarship, " +
                  "#" + _idFollowingMenu + " ." + _classMenu + " .btnscholarship, " +
                  "#" + _idFollowingMenu + " ." + _classMenu + " .btnregisterscholarship, " +
                  "#" + _idFollowingMenu + " ." + _classMenu + " .btnmanagescholarship, " +
                  "#" + _idFollowingMenu + " ." + _classMenu + " .btnimportregisterscholarship, " +
                  "#" + _idFollowingMenu + " ." + _classMenu + " .btnreportscholarship, " +
                  "#" + _idSidebarMenu + " .btnscholarship, " +
                  "#" + _idSidebarMenu + " .btnregisterscholarship, " +
                  "#" + _idSidebarMenu + " .btnmanagescholarship, " +
                  "#" + _idSidebarMenu + " .btnimportregisterscholarship, " +
                  "#" + _idSidebarMenu + " .btnreportscholarship").removeClass("hide");
            }

            if (_param.userLevel == "SUPERUSER" && _param.userFaculty == "MU")
            {
                $("#" + _idHeaderMenu + " ." + _classMenu + " .btnfinancescholarshiptypegroupicl, " +
                  "#" + _idHeaderMenu + " ." + _classMenu + " .btnreportscholarship, " +
                  "#" + _idFollowingMenu + " ." + _classMenu + " .btnfinancescholarshiptypegroupicl, " +
                  "#" + _idFollowingMenu + " ." + _classMenu + " .btnreportscholarship, " +
                  "#" + _idSidebarMenu + " .btnfinancescholarshiptypegroupicl, " +
                  "#" + _idSidebarMenu + " .btnreportscholarship").removeClass("hide");
            }

            if (_param.userLevel == "USER" && _param.userFaculty != "MU")
            {
                $("#" + _idHeaderMenu + " ." + _classMenu + " .btnregisterscholarship, " +
                  "#" + _idFollowingMenu + " ." + _classMenu + " .btnregisterscholarship, " +
                  "#" + _idSidebarMenu + " .btnregisterscholarship").removeClass("hide");
            }

            if (_param.menuActive.length > 0)
            {
                $("#" + _idHeaderMenu + " ." + _classMenu + " .btn" + _param.menuActive + ", " +
                  "#" + _idFollowingMenu + " ." + _classMenu + " .btn" + _param.menuActive + ", " +
                  "#" + _idSidebarMenu + " .btn" + _param.menuActive).addClass("active");
            }
        }
    },

    addCommas: function (_id, _decimalPlaces) {
        $("#" + _id).val(this.blockCharNotWanted($("#" + _id).val()));
        
        var _msg = parseFloat(this.delCommas("#" + _id).length > 0 ? this.delCommas("#" + _id) : "0").toString();

        _msg += "";
        
        var _x = _msg.split(".");
        var _i, _j;

        _x1 = _x[0];

        var _x2 = _x.length > 1 ? "." + _x[1] : "";

        if (_x2.length > 0) _x1 = _x1.length == 0 ? "0" : _x1;
        if (parseInt(_x1) == 0) _x1 = "0";
        if (_x1.length > 0 && _decimalPlaces != null && _decimalPlaces != 0)
        {
            if (_x2.length > 0)
            {
                if (_x[1].length < _decimalPlaces)
                {
                    _i = _decimalPlaces - _x[1].length;

                    for (_j = 0; _j < _i; _j++)
                    {
                        _x[1] = _x[1] + "0";
                    }
                }

                _x2 = "." + _x[1];
            }
            else
                {
                    _x2 = ".";

                    for (_i = 0; _i < _decimalPlaces; _i++)
                    {
                        _x2 = _x2 + "0";
                    }
                }
        }

        var _rgx = /(\d+)(\d{3})/;

        while (_rgx.test(_x1))
        {
            _x1 = _x1.replace(_rgx, "$1" + "," + "$2");
        }

        $("#" + _id).val(_x1 + _x2);

        return _x1 + _x2;
    },

    delCommas: function (_id) {
        var _msg = $(_id).val();

        _msg += "";

        for (var _i = 0; _i < _msg.length; _i++)
            _msg = _msg.replace(",", "");

        return _msg;
    },

    extractNumber: function (_obj, _decimalPlaces, _allowNegative) {
        var _temp = _obj.value;
        var _reg0Str = "[0-9]*";

        if (_decimalPlaces > 0)
            _reg0Str += "\\.?[0-9]{0," + _decimalPlaces + "}";
        else
            if (_decimalPlaces < 0)
                _reg0Str += "\\.?[0-9]*";

        _reg0Str = _allowNegative ? "^-?" + _reg0Str : "^" + _reg0Str;
        _reg0Str = _reg0Str + "$";

        var _reg0 = new RegExp(_reg0Str);

        if (_reg0.test(_temp)) return true;

        var _reg1Str = "[^0-9" + (_decimalPlaces != 0 ? "." : "") + (_allowNegative ? "-" : "") + "]";
        var _reg1 = new RegExp(_reg1Str, "g");

        _temp = _temp.replace(_reg1, "");

        if (_allowNegative)
        {
            var _hasNegative = _temp.length > 0 && _temp.charAt(0) == "-";
            var _reg2 = /-/g;

            _temp = _temp.replace(_reg2, "");

            if (_hasNegative) _temp = "-" + _temp;
        }

        if (_decimalPlaces != 0)
        {
            var _reg3 = /\./g;
            var _reg3Array = _reg3.exec(_temp);
            if (_reg3Array != null) {
                var _reg3Right = _temp.substring(_reg3Array.index + _reg3Array[0].length);

                _reg3Right = _reg3Right.replace(_reg3, "");
                _reg3Right = _decimalPlaces > 0 ? _reg3Right.substring(0, _decimalPlaces) : _reg3Right;
                _temp = _temp.substring(0, _reg3Array.index) + "." + _reg3Right;
            }
        }

        _obj.value = _temp;
    },

    blockCharNotWanted: function (_msg) {
        var _tempTxt = _msg;
        var _reg = "----------**********..........00000000000000000000.00";
        var _i;

        if (_reg.indexOf(_tempTxt) >= 0) _msg = "";
        
        _msg = _msg.replace("??????????", "?");
        _msg = _msg.replace("?????????", "?");
        _msg = _msg.replace("????????", "?");
        _msg = _msg.replace("???????", "?");
        _msg = _msg.replace("??????", "?");
        _msg = _msg.replace("?????", "?");
        _msg = _msg.replace("????", "?");
        _msg = _msg.replace("???", "?");
        _msg = _msg.replace("??", "?");        

        return _msg;
    },

    blockNonNumbers: function (_obj, _e, _allowDecimal, _allowNegative) {
        var _key;
        var _isCtrl = false;
        var _keychar;
        var _reg;

        if (window.event)
        {
            _key = _e.keyCode;
            _isCtrl = window.event.ctrlKey
        }
        else
            {
                if (_e.which)
                {
                    _key    = _e.which;
                    _isCtrl = _e.ctrlKey;
                }
            }

        if (isNaN(_key)) return true;

        _keychar = String.fromCharCode(_key);

        if (_key == 8 || _isCtrl) return true;

        _reg = /\d/;

        var _isFirstN = _allowNegative ? _keychar == "-" && _obj.value.indexOf("-") == -1 : false;
        var _isFirstD = _allowDecimal ? _keychar == "." && _obj.value.indexOf(".") == -1 : false;

        return _isFirstN || _isFirstD || _reg.test(_keychar);
    },

    trim: function (_id) {
        return $(_id).val($.trim($(_id).val()));
    },

    initTextSelect: function () {
        var _this = this;

        $(function () {
            $(function () {
                if (BrowserDetect.browser == "Explorer")
                {
                    $(".table tbody td .ui.form .ui.icon.input i.icon").css({
                        "top": "2px"
                    });
                    $(".table tbody td .ui.form .ui.icon.input input").css({
                        "margin-top": "5px"
                    });
                }

                if (BrowserDetect.browser == "Mozilla")
                {
                    $(".table tbody td .ui.form .ui.icon.input > i.icon").css({
                        "top": "2px"
                    });
                    $(".table tbody td .ui.form .ui.icon.input > input").css({
                        "margin-top": "5px"
                    });
                }

                $("input:text, input:password, textarea").focus(function () {
                    if ($(this).hasClass("textbox-numeric") == true)
                        $(this).val(_this.delCommas("#" + $(this).attr("id")));
                });
                $("input:text, input:password, textarea").mouseup(function (_e) {
                    if ($(this).is(":disabled") == false)
                        _e.preventDefault();
                });
                $("input:text, input:password, textarea").blur(function () {
                    _this.trim("#" + $(this).attr("id"));

                    $(this).val(_this.blockCharNotWanted($(this).val()));
                });
                $(".inputcalendar").keydown(function (_e) {
                    var _keyCode = _e.keyCode || _e.which;
                    
                    if (_e.keyCode != 8 && _e.keyCode != 46 && _e.keyCode != 9 && _e.keyCode != 37 && _e.keyCode != 39)
                        return false;
                    else
                        return true;
                });

                $(".inputcalendar").change(function () {
                    if ($(this).val().length < 10)
                        $(this).val("");
                });
            });
        });
    },

    initCheck: function (_param) {
        _param.id = (_param.id == undefined ? "" : _param.id);

        $(_param.id).iCheck({
            checkboxClass: "icheckbox_minimal",
            radioClass: "iradio_minimal"
        });
    },

    initCalendar: function (_param) {
        _param.id = (_param.id == undefined ? "" : _param.id);

        $(_param.id).calendar({
            type: "date",
            monthFirst: false
        });
    },

    initMenu: function () {
        var _this = this;
        
        _this.initDropdown({
            id: "#header",
        }, function (_result) {
            alert(_result);
        });
        _this.initDropdown({
            id: "#followingmenu",
        }, function (_result) {
        });

        $(function () {
            $(".menu .item").click(function () {
                if ($(this).hasClass("btnscholarship"))
                    _this.gotoPage({
                        page: ("index.aspx?p=" + _this.pageScholarshipMain + "&lang=" + _this.lang)
                    });
                if ($(this).hasClass("btnregisterscholarship"))
                    _this.gotoPage({
                        page: ("index.aspx?p=" + _this.pageRegisterScholarshipMain + "&lang=" + _this.lang)
                    });
                if ($(this).hasClass("btnmanagescholarship"))
                    _this.gotoPage({
                        page: ("index.aspx?p=" + _this.pageManageScholarshipMain + "&lang=" + _this.lang)
                    });
                if ($(this).hasClass("btnimportregisterscholarship"))
                    _this.gotoPage({
                        page: ("index.aspx?p=" + _this.pageImportRegisterScholarshipMain + "&lang=" + _this.lang)
                    });
                if ($(this).hasClass("btnfinancescholarshiptypegroupicl"))
                    _this.gotoPage({
                        page: ("index.aspx?p=" + _this.pageFinanceScholarshipTypeGroupICLMain + "&lang=" + _this.lang)
                    });
                if ($(this).hasClass("btnreportscholarship"))
                    _this.gotoPage({
                        page: ("index.aspx?p=" + _this.pageReportScholarshipMain + "&lang=" + _this.lang)
                    });
            });
        });
    },

    uncheckboxRoot: function (_id) {
        if ($(_id).is(":checked") == true)
        {
            $(_id).iCheck("uncheck");
        }
    },

    uncheckboxAll: function (_param) {
        _param.idTable  = (_param.idTable == undefined ? "" : _param.idTable);

        _obj = (_param.idTable + " .select-child");

        if ($(_param.idTable + " .select-root").is(":checked") == false)
        {
            if (parseInt($(_obj + ":checked").length) == parseInt($(_obj).length))
            {
                $(_obj).iCheck("uncheck");

                return "uncheck";
            }

            return "";
        }
        else
            {
                $(_obj).iCheck("check");

                return "check";
            }          
    },

    initTable: function (_param) {
        _param.id = (_param.id == undefined ? "" : _param.id);

        var _this = this;

        $(_param.id + " .select-root").on("ifChanged", function (_e) {
            var _result = _this.uncheckboxAll({
                            idTable: _param.id
                          });
        });
        
        $(_param.id + " .select-child").on("ifUnchecked", function () {
            _this.uncheckboxRoot(_param.id + " .select-root");
        });

        _this.getDialogFormOnClick({
            id: _param.id
        });

        _this.initTextSelect();
    },

    initShrinkPanel: function (_param) {
        _param.id = (_param.id == undefined ? "" : _param.id);

        var _this = this;
        
        $(_param.id + " .btnshrink").click(function () {
            var _idContent = (_param.id + " .panel-bodys");

            if ($(_idContent).is(":visible") == false)
            {
                $(this).removeClass("plus").addClass("minus");
                $(_idContent).show();
            }
            else
                {
                    $(this).removeClass("minus").addClass("plus");
                    $(_idContent).hide();
                }

            _this.setBodyLayout();
        });
    },

    initClosePanel: function (_param, _callBackFunc) {
        _param.id       = (_param.id == undefined ? "" : _param.id);
        _param.hide     = (_param.hide == undefined || _param.hide == "" ? false : _param.hide);
        _param.idHide   = (_param.idHide == undefined ? "" : _param.idHide);
        _param.show     = (_param.show == undefined || _param.show == "" ? false : _param.show);
        _param.idShow   = (_param.idShow == undefined ? "" : _param.idShow);

        var _this = this;

        $(_param.id + " .btnclose").click(function () {
            if (_param.id.length > 0) $(_param.id).html("");
            if (_param.hide == true && _param.idHide.length > 0)
            {
                $(_param.idHide).hide();
            }
            if (_param.show == true && _param.idShow.length > 0)
            {
                $(_param.idShow).show();
            }

            _this.setBodyLayout();

            _callBackFunc();
        });
    },

    initDropdown: function (_param, _callBackFunc) {        
        _param.id = (_param.id == undefined ? "" : _param.id);

        var _this = this;

        $(_param.id + " .combobox").dropdown({
            onChange: function (_value, _text) {
                _this.setSelectDropdown({
                    id: $(this).attr("id")
                }, function (_result) {
                    _callBackFunc(_result);
                });
            },
            onNoResults: function () {
            }
        });
    },

    initTooltip: function (_param, _callBackFunc) {
        _param.id = (_param.id == undefined ? "" : _param.id);

        var _this = this;

        $(_param.id).popup({            
            position: "top center",
            /*onShow: function () {
                $(_param.id).attr("data-content", $(_param.id).attr("data-content" + _this.lang.toLowerCase()));
            }
            */
        });
    },

    initBrowseFile: function (_param, _callBackFunc) {
        _param.id = (_param.id == undefined ? "" : _param.id);

        var _this = this;

        $(".browsefile " + _param.id + "-relativefile").prop("disabled", true);
           
        $(".browsefile " + _param.id + "-absolutefile").change(function () {
            var _fileName = $(this).val().split("\\").pop();

            $(".browsefile " + _param.id + "-relativefile").val(_fileName.toLowerCase());

            _callBackFunc(_fileName);
        });
    },

    getDropdrownValue: function (_param) {
        _param.id = (_param.id == undefined ? "" : _param.id);

        return $(_param.id).dropdown("get value");
    },

    getCalendarValue: function (_param) {
        _param.id = (_param.id == undefined ? "" : _param.id);

        return $(_param.id + " input:text").val();
    },

    setCalendarValue: function (_param) {
        _param.id       = (_param.id == undefined ? "" : _param.id);
        _param.value    = (_param.value == undefined ? "" : _param.value);

        $(_param.id).calendar("set date", _param.value);
    },

    setSelectDropdown: function (_param, _callBackFunc) {
        _param.id = (_param.id == undefined ? "" : _param.id);

        var _this = this;
        var _cmd;
        var _idContent;
        var _idDropdown;
        var _idContainer;
        var _page;
        var _data = {};
        var _facultyId;
        var _scholarshipsYearSemester;
        var _scholarshipsYear;
        var _semester;
        
        if (_param.id == ("search-" + _this.subjectRegisterScholarship.toLowerCase() + "-faculty") ||
            _param.id == ("search-" + _this.subjectManageScholarship.toLowerCase() + "-faculty") ||
            _param.id == ("import-" + _this.subjectImportRegisterScholarship.toLowerCase() + "-faculty") ||
            _param.id == ("search-" + _this.subjectFinanceScholarshipTypeGroupICLClassificationRecipientFinance.toLowerCase() + "-faculty") ||
            _param.id == ("search-" + _this.subjectReportListOfPeopleApprovedFinanceFromICL.toLowerCase() + "-faculty"))
        {
            if (_param.id == ("search-" + _this.subjectRegisterScholarship.toLowerCase() + "-faculty") ||
                _param.id == ("search-" + _this.subjectManageScholarship.toLowerCase() + "-faculty") ||
                _param.id == ("import-" + _this.subjectImportRegisterScholarship.toLowerCase() + "-faculty") ||
                _param.id == ("search-" + _this.subjectFinanceScholarshipTypeGroupICLClassificationRecipientFinance.toLowerCase() + "-faculty") ||
                _param.id == ("search-" + _this.subjectReportListOfPeopleApprovedFinanceFromICL.toLowerCase() + "-faculty"))
            {
                _idContent      = _param.id.replace("-faculty", "");
                _cmd            = "getprogram";
                _idDropdown     = (_idContent + "-program");
                _idContainer    = (_idContent + "-program-dropdown");
                _facultyId      = _this.getDropdrownValue({
                                    id: ("#" + _param.id)
                                  });
            }

            _cmd                = _cmd;
            _idDropdown         = _idDropdown;
            _idContainer        = _idContainer;
            _data.facultyId     = _facultyId;
            
            _this.loadDropdown({
                cmd: _cmd,
                id: _idDropdown,
                idContainer: _idContainer,
                data: _data
            }, function () {
                _callBackFunc(_idDropdown);
            });
        }        

        if (_param.id == ("search-" + _this.subjectRegisterScholarship.toLowerCase() + "-program") ||
            _param.id == ("search-" + _this.subjectManageScholarship.toLowerCase() + "-program"))
        {
            if (_param.id == ("search-" + _this.subjectRegisterScholarship.toLowerCase() + "-program")) Util.trs.list.clear();
            if (_param.id == ("search-" + _this.subjectManageScholarship.toLowerCase() + "-program"))   Util.tms.list.clear();
        }

        if (_param.id == ("addupdate-" + _this.subjectFinanceScholarshipTypeGroupICLApprovalReceiveFinance.toLowerCase() + "-scholarshipsyearsemester"))
        {            
            if ($("#addupdate-" + _this.subjectFinanceScholarshipTypeGroupICLApprovalReceiveFinance.toLowerCase() + "-lotno-hidden").val().length == 0)
            {
                _idContent                  = _param.id.replace("-scholarshipsyearsemester", "");
                _cmd                        = "getmaxlotapprovalreceivefinance";
                _idContainer                = (_idContent + "-lotno");
                _scholarshipsYearSemester   = _this.getDropdrownValue({
                                                id: ("#" + _param.id)
                                              });
            
                if (_scholarshipsYearSemester != "0")
                {
                    _data.action                = "get";
                    _data.cmd                   = _cmd;
                    _data.scholarshipsTypeGroup = _this.subjectICL;
                    _data.scholarshipsYear      = (_scholarshipsYearSemester.length > 0 ? _scholarshipsYearSemester.split(":")[0] : "");
                    _data.semester              = (_scholarshipsYearSemester.length > 0 ? _scholarshipsYearSemester.split(":")[1] : "");

                    _this.msgPreloading = "";

                    _this.loadAjax({
                        url: _this.urlHandler,
                        method: "POST",
                        data: _data
                    }, function (_result) {
                        $("#" + _idContainer).val(_result.MaxLotNo);

                        _callBackFunc(_param.id);
                    });
                }
                else
                    $("#" + _idContainer).val("");
            }
        }

        if (_param.id == ("search-" + _this.subjectFinanceScholarshipTypeGroupICLClassificationRecipientFinance.toLowerCase() + "-scholarshipsyearsemester") ||
            _param.id == ("search-" + _this.subjectReportListOfPeopleApprovedFinanceFromICL.toLowerCase() + "-scholarshipsyearsemester"))
        {
            _idContent                  = _param.id.replace("-scholarshipsyearsemester", "");
            _cmd                        = "getlotno";
            _idDropdown                 = (_idContent + "-lotno");
            _idContainer                = (_idContent + "-lotno-dropdown");
            _scholarshipsYearSemester   = _this.getDropdrownValue({
                                            id: ("#" + _param.id)
                                          });

            _cmd                        = _cmd;
            _idDropdown                 = _idDropdown;
            _idContainer                = _idContainer;
            _data.scholarshipsTypeGroup = (_scholarshipsYearSemester != "0" ? _this.subjectICL : "");
            _data.scholarshipsYear      = (_scholarshipsYearSemester != "0" ? _scholarshipsYearSemester.split(":")[0] : "");
            _data.semester              = (_scholarshipsYearSemester != "0" ? _scholarshipsYearSemester.split(":")[1] : "");

            _this.loadDropdown({
                cmd: _cmd,
                id: _idDropdown,
                idContainer: _idContainer,
                data: _data
            }, function () {
                _callBackFunc(_idDropdown);
            });
        }

        _callBackFunc(_param.id);
    },
    
    getPagination: function () {
        var _this = this;

        $("table").each(function () {
            var $table = $(this);
            var _currentPage = 0;
            var _rowPerPage = 0;

            _rowPerPage = _this.rowPerPage;

            $table.bind("repaginate", function () {
                $table.find("tbody tr.table-row").hide().slice(_currentPage * _this.rowPerPage, (_currentPage + 1) * _this.rowPerPage).show();
                _this.currentPage = (_currentPage * _this.rowPerPage, (_currentPage + 1) * _this.rowPerPage);
                $("tbody tr.table-row").addClass("p_" + _this.currentPage);
            });

            $table.trigger("repaginate");

            var _numRows = $table.find("tbody tr.table-row").length;
            var _numPages = Math.ceil(_numRows / _this.rowPerPage);
            var $pager = $("<div class='pager'></div>");

            for (var _page = 0; _page < _numPages; _page++)
            {
                $("<span class='page-number'></span>").text(_page + 1).bind("click", {
                    newPage: _page
                }, function (_e) {
                    _currentPage = _e.data["newPage"];
                    _this.currentPage = _currentPage;
                    $table.trigger("repaginate");
                    $(this).addClass("active").siblings().removeClass("active");
                }).appendTo($pager).addClass("clickable");
            }
            $pager.insertAfter($table).find("span.page-number:first").addClass("active");
        });
    },

    getSelectionIsSelect: function (_param) {
        _param.id           = (_param.id == undefined ? "" : _param.id);
        _param.type         = (_param.type == undefined ? "" : _param.type);
        _param.valueTrue    = (_param.valueTrue == undefined ? "" : _param.valueTrue);
        _param.valueFalse   = (_param.valueFalse == undefined ? "" : _param.valueFalse);
       
        var _this = this;

        if (_param.id.length > 0 && _param.type.length > 0)
        {
            if (_param.type == "select")    return (_this.getDropdrownValue({ id: _param.id }) != "0" ? _param.valueTrue : _param.valueFalse);
            if (_param.type == "radio")     return ($("input[name=" + _param.id + "]:radio").is(":checked") == true && $("input[name=" + _param.id + "]:checked").val() != "0" ? _param.valueTrue : _param.valueFalse);
            if (_param.type == "checkbox")  return ($("input[name=" + _param.id + "]:checkbox").is(":checked") == true && $("input[name=" + _param.id + "]:checked").val() != "0" ? _param.valueTrue : _param.valueFalse);
        }

        return "";
    },

    getValueSelectCheck: function (_param) {
        _param.id       = (_param.id == undefined ? "" : _param.id);
        _param.idParent = (_param.idParent == undefined ? "" : _param.idParent);

        var _idSelectCheck = $((_param.idParent.length > 0 ? (_param.idParent + " ") : "") + "input[name=" + _param.id + "]:checked");
        var _countSelectCheck = _idSelectCheck.length;
        var _selectResult = new Array();

        if (_countSelectCheck > 0)
        {
            _idSelectCheck.each(function (_i) {
                _selectResult[_i] = this.value;
            });
        }

        return _selectResult;
    },

    setLanguage: function (_param) {
        _param.lang = (_param.lang == undefined || _param.lang == "" ? this.lang : _param.lang);

        var _this = this;
        var _i = 0;
        var _j = 0;
        var _idTable;

        if (_param.lang != "TH" && _param.lang != "EN")
            _param.lang = _this.lang;

        _this.lang = _param.lang;

        $(".lang").hide();
        $(".lang-" + _this.lang.toLowerCase()).show();

        for (_i = 0; _i < $("input:text").length; _i++)
        {
            $("input:text:eq(" + _i + ")").attr("placeholder", $("input:text:eq(" + _i + ")").attr("placeholder" + _this.lang.toLowerCase()));
        }

        for (_i = 0; _i < $("table").length; _i++)
        {
            _idTable = ("table:eq(" + _i + ")");

            if ($(_idTable).is(":visible") == true)
            {
                for (_j = 0; _j < $(_idTable + " thead th").length; _j++)
                {
                    $(_idTable + " td.tooltip.col" + (_j + 1)).attr("data-content", $(_idTable + " td.tooltip.col" + (_j + 1)).attr("data-content" + _this.lang.toLowerCase()));
                    $(_idTable + " td.tooltip.col" + (_j + 1)).attr("data-html", $(_idTable + " td.tooltip.col" + (_j + 1)).attr("data-html" + _this.lang.toLowerCase()));
                }
            }
        }
    },

    setLanguageOnForm: function (_param) {
        _param.id = (_param.id == undefined ? "" : _param.id);

        var _this = this;
        var _i = 0;

        if (_param.id.length > 0)
        {
            $(_param.id + " .lang").hide();
            $(_param.id + " .lang-" + _this.lang.toLowerCase()).show();

            for (_i = 0; _i < $("input:text").length; _i++)
            {
                $("input:text:eq(" + _i + ")").attr("placeholder", $("input:text:eq(" + _i + ")").attr("placeholder" + _this.lang.toLowerCase()));
            }

            for (_i = 0; _i < $("table thead th").length; _i++)
            {
                $(_param.id + " table td.tooltip.col" + (_i + 1)).attr("data-content", $(_param.id + " table td.tooltip.col" + (_i + 1)).attr("data-content" + _this.lang.toLowerCase()));
                $(_param.id + " table td.tooltip.col" + (_i + 1)).attr("data-html", $(_param.id + " table td.tooltip.col" + (_i + 1)).attr("data-html" + _this.lang.toLowerCase()));
            }
        }
    },

    initMain: function () {
        var _this = this;

        $(".lang-active a").click(function () {
            $(this).blur();

            _this.setLanguage({
                lang: $(this).attr("alt")
            });
        });

        $("#main-keyword").val("");

        $("#main-keyword").keypress(function () {            
            if ($(".btnscholarship").hasClass("active"))
                Util.tsl.list.clear();
            
            if ($(".btnregisterscholarship").hasClass("active"))
                Util.trs.list.clear();

            if ($(".btnmanagescholarship").hasClass("active"))
                Util.tms.list.clear();

            if ($("#" + Util.tfs.ICL.savePeopleApproved.idContent).is(":visible") == true)
                Util.tfs.ICL.savePeopleApproved.list.clear();

            if ($("#" + Util.tfs.ICL.classificationRecipientFinance.idContent).is(":visible") == true)
                Util.tfs.ICL.classificationRecipientFinance.list.clear();

            if ($("#" + Util.tfs.ICL.savePeoplePayCheque.idContent).is(":visible") == true)
                Util.tfs.ICL.savePeoplePayCheque.list.clear();

            if ($("#" + Util.tps.listOfPeopleApprovedFinanceFromICL.idContent).is(":visible") == true)
                Util.tps.listOfPeopleApprovedFinanceFromICL.list.clear();
        });

        $("#main-keyword").keyup(function (_e) {
            if (_e.keyCode == 13)
            {
                $(this).blur();
                $("#main-btnquicksearch").click();
            }
        });

        $("#main-btnquicksearch").click(function () {
            $("#main-keyword").blur();

            var _keyword = $.trim($("#main-keyword").val());

            if ($(".btnscholarship").hasClass("active"))
                $("#" + Util.tsl.search.idContent + "-btnsearch").click();

            if ($(".btnregisterscholarship").hasClass("active"))
                $("#" + Util.trs.search.idContent + "-btnsearch").click();

            if ($(".btnmanagescholarship").hasClass("active"))
                $("#" + Util.tms.search.idContent + "-btnsearch").click();

            if ($("#" + Util.tfs.ICL.savePeopleApproved.idContent).is(":visible") == true)
                $("#" + Util.tfs.ICL.savePeopleApproved.search.idContent + "-btnsearch").click();

            if ($("#" + Util.tfs.ICL.classificationRecipientFinance.idContent).is(":visible") == true)
                $("#" + Util.tfs.ICL.classificationRecipientFinance.search.idContent + "-btnsearch").click();

            if ($("#" + Util.tfs.ICL.savePeoplePayCheque.idContent).is(":visible") == true)
                $("#" + Util.tfs.ICL.savePeoplePayCheque.search.idContent + "-btnsearch").click();

            if ($("#" + Util.tps.listOfPeopleApprovedFinanceFromICL.idContent).is(":visible") == true)0
                $("#" + Util.tps.listOfPeopleApprovedFinanceFromICL.search.idContent + "-btnsearch").click();
        });
    },

    setDialogFormOnClick: function () {
        var _this = this;
        var _saveResult;
        var _page;

        $(".dialogform .btnclose").click(function () {
            if ($("#" + Util.trs.addupdate.idContent).is(":visible") ||
                $("#" + Util.tms.addupdate.idContent).is(":visible") ||
                $("#" + Util.tms.ICL.addupdate.idContent).is(":visible") ||
                $("#" + Util.tfs.ICL.savePeopleApproved.addupdate.idContent).is(":visible") ||
                $("#" + Util.tfs.ICL.classificationRecipientFinance.addupdate.idContent).is(":visible") ||
                $("#" + Util.tfs.ICL.savePeoplePayCheque.addupdate.idContent).is(":visible"))
            {
                if ($("#" + Util.trs.addupdate.idContent).is(":visible"))
                {
                    _saveResult = $("#" + Util.trs.addupdate.idContent + "-saveresult").val();

                    $("#" + Util.trs.addupdate.idContent + "-saveresult").val("");

                    Util.dialogClose();
                    $(".dialogform").modal("hide");

                    if (_saveResult == "Y")
                    {
                        _this.gotoNavPage({
                            page: _this.pageRegisterScholarshipMain,
                            currentPage: _this.currentPage,
                            startRow: _this.startRow,
                            endRow: _this.endRow
                        });
                    }
                }
                if ($("#" + Util.tms.addupdate.idContent).is(":visible"))
                {
                    _page       = $("#" + Util.tms.addupdate.idContent + "-btnsave").attr("alt");
                    _saveResult = $("#" + Util.tms.addupdate.idContent + "-saveresult").val();

                    $("#" + Util.tms.addupdate.idContent + "-saveresult").val("");

                    Util.dialogClose();
                    $(".dialogform").modal("hide");

                    if (_saveResult == "Y")
                    {
                        _this.gotoNavPage({
                            page: _this.pageManageScholarshipMain,
                            currentPage: _this.currentPage,
                            startRow: _this.startRow,
                            endRow: _this.endRow
                        });
                    }
                }
                if ($("#" + Util.tms.ICL.addupdate.idContent).is(":visible"))
                {
                    _saveResult = $("#" + Util.tms.ICL.addupdate.idContent + "-saveresult").val();

                    $("#" + Util.tms.ICL.addupdate.idContent + "-saveresult").val("");

                    Util.dialogClose();
                    $(".dialogform").modal("hide");

                    if (_saveResult == "Y")
                    {
                        _this.gotoNavPage({
                            page: _this.pageManageScholarshipMain,
                            currentPage: _this.currentPage,
                            startRow: _this.startRow,
                            endRow: _this.endRow
                        });
                    }
                }
                if ($("#" + Util.tfs.ICL.savePeopleApproved.addupdate.idContent).is(":visible"))
                {
                    _saveResult = $("#" + Util.tfs.ICL.savePeopleApproved.addupdate.idContent + "-saveresult").val();
                    
                    $("#" + Util.tfs.ICL.savePeopleApproved.addupdate.idContent + "-saveresult").val("");

                    Util.dialogClose();
                    $(".dialogform").modal("hide");

                    if (_saveResult == "Y")
                    {
                        _this.gotoNavPage({
                            page: _this.pageFinanceScholarshipTypeGroupICLSavePeopleApprovedMain,
                            currentPage: _this.currentPage,
                            startRow: _this.startRow,
                            endRow: _this.endRow
                        });
                    }
                }
                if ($("#" + Util.tfs.ICL.classificationRecipientFinance.addupdate.idContent).is(":visible"))
                {
                    _saveResult = $("#" + Util.tfs.ICL.classificationRecipientFinance.addupdate.idContent + "-saveresult").val();
                    
                    $("#" + Util.tfs.ICL.classificationRecipientFinance.addupdate.idContent + "-saveresult").val("");

                    Util.dialogClose();
                    $(".dialogform").modal("hide");

                    if (_saveResult == "Y")
                    {
                        _this.gotoNavPage({
                            page: _this.pageFinanceScholarshipTypeGroupICLClassificationRecipientFinanceMain,
                            currentPage: _this.currentPage,
                            startRow: _this.startRow,
                            endRow: _this.endRow
                        });
                    }
                }
                if ($("#" + Util.tfs.ICL.savePeoplePayCheque.addupdate.idContent).is(":visible"))
                {
                    _saveResult = $("#" + Util.tfs.ICL.savePeoplePayCheque.addupdate.idContent + "-saveresult").val();
                    
                    $("#" + Util.tfs.ICL.savePeoplePayCheque.addupdate.idContent + "-saveresult").val("");

                    Util.dialogClose();
                    $(".dialogform").modal("hide");

                    if (_saveResult == "Y")
                    {
                        _this.gotoNavPage({
                            page: _this.pageFinanceScholarshipTypeGroupICLSavePeoplePayChequeMain,
                            currentPage: _this.currentPage,
                            startRow: _this.startRow,
                            endRow: _this.endRow
                        });
                    }
                }
            }
            else
                {
                    Util.dialogClose();

                    if ($(this).data("option") == "dialogform2")
                    {
                        $(".dialogform2").modal("hide");
                        $(".dialogform1").dimmer("hide");
                        $(".dialogform1").modal("refresh");
                    }
                    else
                        $(".dialogform").modal("hide");
                }
        });
    },

    getDialogFormOnClick: function (_param) {
        _param.id = (_param.id == undefined ? "" : _param.id);

        var _this = this;
        var _page = "";
        var _data = "";
        var _idActive;

        $(_param.id + " .link-click").click(function () {
            if ($(this).hasClass("link-" + _this.subjectMeaningofScholarshipPayType.toLowerCase()) == true) _page = _this.pageMeaningofScholarshipPayTypeMain;

            _idActive = "";

            if (_page.length > 0)
            {
                Util.loadForm({
                    name: _page,
                    dialog: true,
                }, function (_result, _e) {
                });
            }
        });
    },

    getStudentPicture: function (_param) {
        _param.id   = (_param.id == undefined ? "" : _param.id)
        _param.src  = (_param.src == undefined ? "" : _param.src)

        var _this = this;

        if (_param.src.length > 0)
        {
            $(_param.id + " .avatar .watermark").show();
            $(_param.id + " .profilepicture img").prop({ "src": _param.src }).show();
        }
        else
            {
                $(_param.id + " .avatar .watermark").hide();
                $(_param.id + " .profilepicture img").hide();
            }
    },

    viewFile: function (_param) {
        _param.url = (_param.url == undefined ? "" : _param.url)

        if (_param.url.length > 0)
            window.location = _param.url;
    }
}