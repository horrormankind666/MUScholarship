var SCHFinanceScholarship = {
    ICL: {
        main: {
            idContent: ("main-" + SCHUtil.subjectFinanceScholarshipTypeGroupICL.toLowerCase()),

            init: function () {
                var _this1 = this;
                var _this2;

                $("#" + _this1.idContent + " .tabular.menu .item").tab({
                    "onVisible": function () {
                                    var _idContent = $(this).attr("id");
                                    var _page;

                                    $("body").css("min-width", "0px");
                                    $("#main-quicksearch").addClass("hide");
                                    $("#main-keyword").val("");
                                    Util.setBodyLayout();

                                    if (_idContent == ("tab-" + SCHUtil.subjectFinanceScholarshipTypeGroupICLApprovalReceiveFinance.toLowerCase()))
                                    {
                                        $("body").css("min-width", "477px");

                                        if ($("#" + Util.tfs.ICL.savePeopleApproved.idContent).is(":visible") == true)
                                        {
                                            $("#main-quicksearch").removeClass("hide");
                                            $("#main-keyword").val("");
                                        }
                                    }
                                    if (_idContent == ("tab-" + SCHUtil.subjectFinanceScholarshipTypeGroupICLClassificationRecipientFinance.toLowerCase()))
                                    {
                                        $("body").css("min-width", "658px");
                                        $("#main-quicksearch").removeClass("hide");
                                        $("#main-keyword").val("");
                                        _page   = Util.pageFinanceScholarshipTypeGroupICLClassificationRecipientFinanceMain;
                                        _this2  = Util.tfs.ICL.classificationRecipientFinance;
                                    }
                                    if (_idContent == ("tab-" + SCHUtil.subjectFinanceScholarshipTypeGroupICLPayCheque.toLowerCase()))
                                    {
                                        $("body").css("min-width", "765px");
                                        _page   = Util.pageFinanceScholarshipTypeGroupICLPayChequeMain;
                                        _this2  = Util.tfs.ICL.payCheque;

                                        if ($("#" + Util.tfs.ICL.savePeoplePayCheque.idContent).is(":visible") == true)
                                        {
                                            $("#main-quicksearch").removeClass("hide");
                                            $("#main-keyword").val("");
                                        }
                                    }

                                    if ($("#" + _idContent).html().length == 0)
                                    {
                                        
                                        Util.loadForm({
                                            name: _page,
                                            id: ("#" + _idContent)
                                        }, function (_result) {
                                            if (_result.MainContent.length > 0)
                                            {
                                                Util.setBodyLayout();
                                                _this2.init();
                                            }
                                        });            
                                    }                                        
                                 }
                });
                Util.tfs.ICL.approvalReceiveFinance.init();
            }
        },

        approvalReceiveFinance: {
            idContent: ("main-" + SCHUtil.subjectFinanceScholarshipTypeGroupICLApprovalReceiveFinance.toLowerCase()),
            firstLoad: true,

            init: function () {
                var _this = this;

                $("body").css("min-width", "477px");
                $("#main-quicksearch").addClass("hide");

                $("#" + Util.tfs.ICL.savePeopleApproved.idContent).hide();

                $("#" + _this.idContent + " .button").click(function () {
                    var _idContent = $(this).attr("id");

                    $(this).blur();

                    if (_idContent == (_this.idContent + "-btnadd"))
                    {
                        Util.loadForm({
                            name: Util.pageFinanceScholarshipTypeGroupICLApprovalReceiveFinanceAdd,
                            id: ("#" + _this.addupdate.idContent)
                        }, function (_result) {
                            _this.addupdate.init({
                                page: Util.pageFinanceScholarshipTypeGroupICLApprovalReceiveFinanceAdd
                            });
                        });
                    }
                });

                _this.search.init();
                $("#" + _this.search.idContent + "-btnsearch").click();
            },

            search: {
                idContent: ("search-" + SCHUtil.subjectFinanceScholarshipTypeGroupICLApprovalReceiveFinance.toLowerCase()),

                init: function () {
                    var _this = this;

                    Util.initShrinkPanel({
                        id: ("#" + _this.idContent)
                    });
                    Util.initDropdown({
                        id: ("#" + _this.idContent)
                    }, function (_result) {
                        Util.tfs.ICL.approvalReceiveFinance.list.clear();
                    });

                    $("#" + _this.idContent + " .button").click(function () {
                        var _idContent = $(this).attr("id");

                        $(this).blur();

                        if (_idContent == (_this.idContent + "-btnsearch"))
                        {
                            if (_this.validate())
                            {
                                _this.action(function () {
                                    if (Util.tfs.ICL.approvalReceiveFinance.firstLoad == false)
                                    {
                                        Util.gotoElement({
                                            anchorName: ("#" + Util.tfs.ICL.approvalReceiveFinance.list.idContent),
                                            top: ($("#followingmenu").outerHeight())
                                        });
                                    }

                                    Util.tfs.ICL.approvalReceiveFinance.firstLoad = false;
                                });
                            }
                        }
                    });
                },

                validate: function () {
                    var _error = false;
                    var _msgTH;
                    var _msgEN;
 
                    return (_error == false ? true : false);
                },
            
                value: function () {
                    var _this = this;
                    var _data = {};
                    var _scholarshipsYearSemester   = Util.getSelectionIsSelect({
                                                        id: ("#" + _this.idContent + "-scholarshipsyearsemester"),
                                                        type: "select",
                                                        valueTrue: Util.getDropdrownValue({
                                                                        id: ("#" + _this.idContent + "-scholarshipsyearsemester")
                                                                   })
                                                      });

                    _data.scholarshipsTypeGroup = Util.subjectICL;
                    _data.scholarshipsYear      = (_scholarshipsYearSemester.length > 0 ? _scholarshipsYearSemester.split(":")[0] : "");
                    _data.semester              = (_scholarshipsYearSemester.length > 0 ? _scholarshipsYearSemester.split(":")[1] : "");

                    return _data;
                },
                
                action: function (_callBackFunc) {
                    var _this = this;
                    var _data = {};
       
                    Util.tfs.ICL.approvalReceiveFinance.list.clear();

                    _data = _this.value();

                    Util.msgPreloading = "Searching...";

                    Util.actionTask({
                        action: "search",
                        page: Util.pageFinanceScholarshipTypeGroupICLApprovalReceiveFinanceMain,
                        data: _data
                    }, function (_result) {
                        $("#" + Util.tfs.ICL.approvalReceiveFinance.list.idContent).html(_result.List);
                        $("#" + Util.tfs.ICL.approvalReceiveFinance.list.idContent + " .recordcountprimary-search").html(_result.RecordCountPrimary);
                        $("#" + Util.tfs.ICL.approvalReceiveFinance.list.idContent + " .table-navpage").html(_result.NavPage);

                        Util.setBodyLayout();
                        Util.setLanguageOnForm({
                            id: ("#" + Util.tfs.ICL.approvalReceiveFinance.list.idContent)
                        });

                        Util.tfs.ICL.approvalReceiveFinance.list.init();
                        _callBackFunc();
                    });
                }
            },

            list: {
                idContent: ("list-" + SCHUtil.subjectFinanceScholarshipTypeGroupICLApprovalReceiveFinance.toLowerCase()),

                init: function () {
                    var _this = this;
                    var _i;
                   
                    for (_i = 0; _i < $("#" + _this.idContent + " table thead th").length; _i++)
                    {
                        Util.initTooltip({
                            id: ("#" + _this.idContent + " table td.col" + (_i + 1))
                        });
                    }
                    Util.initTable({
                        id: ("#" + _this.idContent + " table")
                    });

                    $("#" + _this.idContent + " .button").click(function () {
                        var _idContent;

                        $(this).blur();

                        if ($(this).hasClass("btnupdate"))
                        {
                            Util.loadForm({
                                name: Util.pageFinanceScholarshipTypeGroupICLApprovalReceiveFinanceUpdate,
                                data: $(this).data("value"),
                                id: ("#" + Util.tfs.ICL.approvalReceiveFinance.addupdate.idContent)
                            }, function (_result) {                            
                                if (_result.MainContent.length > 0)
                                    Util.tfs.ICL.approvalReceiveFinance.addupdate.init({
                                        page: Util.pageFinanceScholarshipTypeGroupICLApprovalReceiveFinanceUpdate
                                    });
                            });
                        }
                    });

                    $("#" + _this.idContent + " .link-click").click(function () {
                        if ($(this).hasClass("link-savepeopleapproved"))
                        {
                            var _data = $(this).data("value");;
                            
                            Util.loadForm({
                                name: Util.pageFinanceScholarshipTypeGroupICLSavePeopleApprovedMain,
                                data: (_data.scholarshipsTypeGroup + "|" + _data.scholarshipsYear + "|" + _data.semester + "|" + _data.lotNo),
                                id: ("#" + Util.tfs.ICL.savePeopleApproved.idContent)
                            }, function (_result) {
                                if (_result.MainContent.length > 0)
                                {
                                    $("." + Util.tfs.ICL.approvalReceiveFinance.idContent).hide();
                                    $("#" + Util.tfs.ICL.savePeopleApproved.idContent).show();
                                    $("#main-quicksearch").removeClass("hide");
                                    $("#main-keyword").val("");
                                    Util.setBodyLayout();
                                    Util.gotoTopElement();

                                    Util.tfs.ICL.savePeopleApproved.firstLoad = true;
                                    Util.tfs.ICL.savePeopleApproved.init();
                                    Util.tfs.ICL.savePeopleApproved.search.init();
                                    $("#" + Util.tfs.ICL.savePeopleApproved.search.idContent + "-btnsearch").click();
                                }
                            });            
                        }
                    });
                },

                clear: function () {
                    var _this = this;

                    $("#" + Util.tfs.ICL.approvalReceiveFinance.addupdate.idContent).html("");
                    $("#" + _this.idContent).html("");
                    Util.setBodyLayout();
                },
            },

            addupdate: {
                idContent: ("addupdate-" + SCHUtil.subjectFinanceScholarshipTypeGroupICLApprovalReceiveFinance.toLowerCase()),
                
                init: function (_param) {
                    _param.page = (_param.page == undefined ? "" : _param.page);

                    var _this = this;
                    var _page;

                    Util.initClosePanel({
                        id: ("#" + _this.idContent)
                    }, function () { });
                    Util.initDropdown({
                        id: ("#" + _this.idContent)
                    }, function (_result) {
                    });
                    Util.initCalendar({
                        id: ("#" + _this.idContent + "-deliverdate")
                    });
                    Util.initCalendar({
                        id: ("#" + _this.idContent + "-approvedate")
                    });
                    if (_param.page == Util.pageFinanceScholarshipTypeGroupICLApprovalReceiveFinanceUpdate) $("#" + _this.idContent + "-scholarshipsyearsemester").addClass("disabled");
                    Util.textboxDisable("#" + _this.idContent + "-lotno");

                    $("#" + _this.idContent + " .textbox-numeric").keyup(function () {
                        var _idContent = $(this).attr("id");

                        if (_idContent == (_this.idContent + "-amount"))        return Util.extractNumber(this, 2, false);
                        if (_idContent == (_this.idContent + "-approvenumber")) return Util.extractNumber(this, 0, false);
                    });
                
                    $("#" + _this.idContent + " .textbox-numeric").keypress(function (_e) {
                        return Util.blockNonNumbers(this, _e, true, false);
                    });

                    $("#" + _this.idContent + " .textbox-numeric").focusout(function () {
                        var _idContent = $(this).attr("id");
                        var _decimalPlaces;
                        var _maxLength;

                        if (_idContent == (_this.idContent + "-amount"))
                        {
                            _decimalPlaces  = 2;
                            _maxLength      = 13;
                        }
                        if (_idContent == (_this.idContent + "-approvenumber"))
                        {
                            _decimalPlaces  = 0;
                            _maxLength      = 5;
                        }

                        Util.addCommas(_idContent, _decimalPlaces);
                        ($(this).val($(this).val().length > _maxLength ? $(this).val().substring($(this).val().length, $(this).val().length - _maxLength) : $(this).val()));
                        $(this).val(Util.delCommas("#" + _idContent));
                        Util.addCommas(_idContent, _decimalPlaces);
                        $(this).val(Util.blockCharNotWanted($(this).val()));
                    });

                    $("#" + _this.idContent + " .button").click(function () {
                        var _idContent = $(this).attr("id");

                        $(this).blur();

                        if (_idContent == (_this.idContent + "-btnsave"))
                        {                               
                            _page = $(this).attr("alt");

                            Util.dialogConfirm({
                                msgTH: "ต้องการบันทึกข้อมูลนี้หรือไม่",
                                msgEN: "Do you want to save changes ?",
                                msgButtonCancelTH: "ยกเลิก",
                                msgButtonCancelEN: "Cancel",
                                msgButtonOKTH: "ตกลง",
                                msgButtonOKEN: "OK"
                            }, function (_result) {
                                if (_result == "Y")
                                {
                                    if (_this.validate())
                                        _this.action({
                                            page: _page,
                                            data: _this.value()
                                        });
                                }
                            });
                        }
                    });
                    
                    _this.reset({
                        page: _param.page
                    });                    
                },
                
                reset: function (_param) {
                    _param.page = (_param.page == undefined ? "" : _param.page);

                    var _this = this;

                    Util.gotoElement({
                        anchorName: ("#" + _this.idContent),
                        top: ($("#followingmenu").outerHeight())
                    });
                
                    $("#" + _this.idContent + "-scholarshipsyearsemester").dropdown("set selected", ($("#" + _this.idContent + "-scholarshipsyear-hidden").val() + ":" + $("#" + _this.idContent + "-semester-hidden").val()));
                    $("#" + _this.idContent + "-lotno").val($("#" + _this.idContent + "-lotno-hidden").val());
                    $("#" + _this.idContent + "-deliverno").val($("#" + _this.idContent + "-deliverno-hidden").val());
                    Util.setCalendarValue({
                        id: ("#" + _this.idContent + "-deliverdate"),
                        value: $("#" + _this.idContent + "-deliverdate-hidden").val()
                    });
                    Util.setCalendarValue({
                        id: ("#" + _this.idContent + "-approvedate"),
                        value: $("#" + _this.idContent + "-approvedate-hidden").val()
                    });
                    $("#" + _this.idContent + "-amount").val($("#" + _this.idContent + "-amount-hidden").val());
                    $("#" + _this.idContent + "-approvenumber").val($("#" + _this.idContent + "-approvenumber-hidden").val());
                },
                
                validate: function () {
                    var _this = this;
                    var _error = new Array();
                    var _scholarshipsYearSemester = Util.getDropdrownValue({ id: ("#" + _this.idContent + "-scholarshipsyearsemester") });
                    var _deliverNo = $("#" + _this.idContent + "-deliverno").val();
                    var _deliverDate = Util.getCalendarValue({ id: ("#" + _this.idContent + "-deliverdate") });
                    var _approveDate = Util.getCalendarValue({ id: ("#" + _this.idContent + "-approvedate") });
                    var _amount = Util.delCommas("#" + _this.idContent + "-amount");
                    var _approveNumber = Util.delCommas("#" + _this.idContent + "-approvenumber");
                    var _i = 0;

                    if (_scholarshipsYearSemester == "0")   { _error[_i] = ("กรุณาเลือกปี / ภาคเรียนที่อนุมัติรับเงิน;Please select approval receive finance on year / semester.;"); _i++; }
                    if (_deliverDate.length == 0)           { _error[_i] = ("กรุณาระบุวันที่นำส่ง;Please enter delivery date.;"); _i++; }
                    if (_approveDate.length == 0)           { _error[_i] = ("กรุณาระบุวันที่รับเงิน;Please enter date of receive money.;"); _i++; }
                    if (_amount.length == 0)                { _error[_i] = ("กรุณาระบุจำนวนเงิน;Please enter amount."); _i++; }
                    if (_approveNumber.length == 0)         { _error[_i] = ("กรุณาระบุจำนวนผู้ที่ได้รับอนุมัติ;Please enter number of approval."); _i++; }

                    Util.dialogListMessageError({
                        content: _error
                    });

                    return (_i > 0 ? false : true);
                },

                value: function () {
                    var _this = this;
                    var _data = {};
                    var _scholarshipsYearSemester   = Util.getSelectionIsSelect({
                                                        id: ("#" + _this.idContent + "-scholarshipsyearsemester"),
                                                        type: "select",
                                                        valueTrue: Util.getDropdrownValue({
                                                                        id: ("#" + _this.idContent + "-scholarshipsyearsemester")
                                                                   })
                                                      });

                    _data.id                    = $("#" + _this.idContent + "-id-hidden").val();
                    _data.scholarshipsTypeGroup = Util.subjectICL;
                    _data.scholarshipsYear      = (_scholarshipsYearSemester.length > 0 ? _scholarshipsYearSemester.split(":")[0] : "");
                    _data.semester              = (_scholarshipsYearSemester.length > 0 ? _scholarshipsYearSemester.split(":")[1] : "");
                    _data.lotno                 = $("#" + _this.idContent + "-lotno").val();
                    _data.deliverNo             = $("#" + _this.idContent + "-deliverno").val();
                    _data.deliverDate           = Util.getCalendarValue({ id: ("#" + _this.idContent + "-deliverdate") });
                    _data.approveDate           = Util.getCalendarValue({ id: ("#" + _this.idContent + "-approvedate") });
                    _data.amount                = Util.delCommas("#" + _this.idContent + "-amount");
                    _data.approveNumber         = Util.delCommas("#" + _this.idContent + "-approvenumber");

                    return _data;
                },
                
                action: function (_param) {
                    _param.page = (_param.page == undefined ? "" : _param.page);
                    _param.data = (_param.data == undefined ? {} : _param.data);

                    var _this = this;
                    var _data = _param.data;
                    var _signinYN = "Y";
                    var _error;

                    _data.signinYN = _signinYN;

                    Util.msgPreloading = "Saving...";
        
                    Util.actionTask({
                        action: "save",
                        page: _param.page,
                        data: _data
                    }, function (_result) {
                        _error = Util.getErrorMsg({
                                    signinYN: _signinYN,
                                    pageError: 0,
                                    cookieError: _result.CookieError,
                                    userError: _result.UserError,
                                    saveError: _result.SaveError
                                 });

                        if (_error == false)
                        {                
                            Util.dialogMessage({
                                type: "info",
                                msgTH: "บันทึกข้อมูลเรียบร้อย",
                                msgEN: "Save complete."
                            }, function (_result) {
                                $("#" + _this.idContent + " .btnclose").click();

                                Util.gotoNavPage({
                                    page: Util.pageFinanceScholarshipTypeGroupICLApprovalReceiveFinanceMain,
                                    currentPage: Util.currentPage,
                                    startRow: Util.startRow,
                                    endRow: Util.endRow
                                });
                            });
                        }
                    });
                }
            }
        },

        savePeopleApproved: {
            idContent: ("main-" + SCHUtil.subjectFinanceScholarshipTypeGroupICLSavePeopleApproved.toLowerCase()),
            firstLoad: true,

            init: function () {
                var _this = this;

                Util.initClosePanel({
                    id: ("#" + _this.idContent),
                    hide: true,
                    idHide: ("#" + _this.idContent),
                    show: true,
                    idShow: ("." + Util.tfs.ICL.approvalReceiveFinance.idContent)
                }, function () {
                    $("body").css("min-width", "477px");
                    $("#main-quicksearch").addClass("hide");

                    Util.gotoNavPage({
                        page: Util.pageFinanceScholarshipTypeGroupICLApprovalReceiveFinanceMain,
                        currentPage: Util.currentPage,
                        startRow: Util.startRow,
                        endRow: Util.endRow
                    });
                });
            },

            search: {
                idContent: ("search-" + SCHUtil.subjectFinanceScholarshipTypeGroupICLSavePeopleApproved.toLowerCase()),

                init: function () {
                    var _this = this;

                    Util.initDropdown({
                        id: ("#" + _this.idContent)
                    }, function (_result) {
                        Util.tfs.ICL.savePeopleApproved.list.clear();
                    });

                    $("#" + _this.idContent + " .button").click(function () {
                        var _idContent = $(this).attr("id");

                        $(this).blur();

                        if (_idContent == (_this.idContent + "-btnsearch"))
                        {
                            if (_this.validate())
                                _this.action(function () {
                                    if (Util.tfs.ICL.savePeopleApproved.firstLoad == false)
                                    {
                                        Util.gotoElement({
                                            anchorName: ("#" + Util.tfs.ICL.savePeopleApproved.list.idContent),
                                            top: ($("#followingmenu").outerHeight())
                                        });
                                    }

                                    Util.tfs.ICL.savePeopleApproved.firstLoad = false
                                });
                        }
                    });
                },

                validate: function () {
                    var _error = false;
                    var _msgTH;
                    var _msgEN;
 
                    return (_error == false ? true : false);
                },
            
                value: function () {
                    var _this = this;
                    var _data = {}

                    _data.scholarshipsTypeGroup = $("#" + Util.tfs.ICL.savePeopleApproved.idContent + "-scholarshipstypegroup-hidden").val();
                    _data.scholarshipsYear      = $("#" + Util.tfs.ICL.savePeopleApproved.idContent + "-scholarshipsyear-hidden").val();
                    _data.semester              = $("#" + Util.tfs.ICL.savePeopleApproved.idContent + "-semester-hidden").val();
                    _data.lotNo                 = $("#" + Util.tfs.ICL.savePeopleApproved.idContent + "-lotno-hidden").val();
                    _data.keyword               = $("#main-keyword").val();
                    _data.approveStatus         = Util.getSelectionIsSelect({
                                                    id: ("#" + _this.idContent+ "-approvestatus"),
                                                    type: "select",
                                                    valueTrue: Util.getDropdrownValue({
                                                        id: ("#" + _this.idContent + "-approvestatus")
                                                    })
                                                  });

                    return _data;
                },                

                action: function (_callBackFunc) {
                    var _this = this;
                    var _data = {};
       
                    Util.tfs.ICL.savePeopleApproved.list.clear();

                    _data = _this.value();
                    
                    Util.msgPreloading = "Searching...";

                    Util.actionTask({
                        action: "search",
                        page: Util.pageFinanceScholarshipTypeGroupICLSavePeopleApprovedMain,
                        data: _data
                    }, function (_result) {
                        $("#" + Util.tfs.ICL.savePeopleApproved.list.idContent).html(_result.List);
                        $("#" + Util.tfs.ICL.savePeopleApproved.list.idContent + " .recordcountprimary-search").html(_result.RecordCountPrimary);
                        $("#" + Util.tfs.ICL.savePeopleApproved.list.idContent + " .sum-search").html(_result.Sum);

                        Util.setBodyLayout();
                        Util.setLanguageOnForm({
                            id: ("#" + Util.tfs.ICL.savePeopleApproved.list.idContent)
                        });

                        Util.tfs.ICL.savePeopleApproved.list.init();
                        _callBackFunc();
                    });
                }
            },

            list: {
                idContent: ("list-" + SCHUtil.subjectFinanceScholarshipTypeGroupICLSavePeopleApproved.toLowerCase()),

                init: function () {
                    var _this = this;
                    var _i;
                    
                    Util.initCheck({
                        id: ("#" + _this.idContent + " .checkbox")
                    });
                    for (_i = 0; _i < $("#" + _this.idContent + " table thead th").length; _i++)
                    {
                        Util.initTooltip({
                            id: ("#" + _this.idContent + " table td.col" + (_i + 1))
                        });
                    }
                    Util.initTable({
                        id: ("#" + _this.idContent + " table")
                    });
                    
                    $("#" + _this.idContent + " .button").click(function () {
                        var _data = {};
                        var _idContent;
                        
                        $(this).blur();

                        if ($(this).hasClass("btnstudentcv"))
                        {
                            _data = $(this).data("value");

                            Util.tfs.ICL.studentCV.form({
                                data: _data,
                                idParent: _this.idContent,
                                idMain: Util.tfs.ICL.savePeopleApproved.idContent
                            });
                        }
                    });

                    $("#" + _this.idContent + " .btnapprove-option").click(function () {
                        var _option = $(this).attr("alt");
                        var _scholarshipsTypeGroup;
                        var _scholarshipsYear;
                        var _semester;
                        var _lotNo;

                        $(this).blur();

                        if (_this.option.approve.validate({
                            option: _option
                        }))
                        {
                            _scholarshipsTypeGroup  = $("#" + Util.tfs.ICL.savePeopleApproved.idContent + "-scholarshipstypegroup-hidden").val();
                            _scholarshipsYear       = $("#" + Util.tfs.ICL.savePeopleApproved.idContent + "-scholarshipsyear-hidden").val();
                            _semester               = $("#" + Util.tfs.ICL.savePeopleApproved.idContent + "-semester-hidden").val();
                            _lotNo                  = $("#" + Util.tfs.ICL.savePeopleApproved.idContent + "-lotno-hidden").val();

                            Util.loadForm({
                                name: Util.pageFinanceScholarshipTypeGroupICLSavePeopleApprovedAddUpdate,
                                data: (_scholarshipsTypeGroup + "|" + _scholarshipsYear + "|" + _semester + "|" + _lotNo),
                                dialog: true                                
                            }, function (_result, _e) {                                                                
                                if (_result.MainContent.length > 0)
                                    Util.tfs.ICL.savePeopleApproved.addupdate.init({
                                        option: _option
                                    });
                            });
                        }
                    });
                },

                clear: function () {
                    var _this = this;

                    $("#" + _this.idContent).html("");
                    Util.setBodyLayout();
                },

                option: {
                    approve: {
                        validate: function (_param) {
                            _param.option = (_param.option == undefined ? "" : _param.option);

                            var _this = this;
                            var _error = false;
                            var _msgTH;
                            var _msgEN;
                            var _idContent = ("#" + Util.tfs.ICL.savePeopleApproved.list.idContent + " table" + " .select-child");

                            if (_error == false && _param.option == "all" && $(_idContent).length == 0) { _error = true; _msgTH = "ไม่พบข้อมูล"; _msgEN = "Data not found."; }
                            if (_error == false && _param.option == "selected" && $(_idContent + ":checked").length == 0) { _error = true; _msgTH = "กรุณาเลือกรายการ"; _msgEN = "Please select item."; }

                            if (_error == true)
                            {
                                Util.dialogMessage({
                                    type: "danger",
                                    msgTH: _msgTH,
                                    msgEN: _msgEN
                                }, function (_result) { });

                                return false;
                            }

                            return true;
                        }
                    }
                },

                form: {
                    reset: function (_param) {
                        _param.idParent = (_param.idParent == undefined ? "" : _param.idParent);
                        _param.idMain   = (_param.idMain == undefined ? "" : _param.idMain);
                
                        $(_param.idParent + " td").html("");
                        $(_param.idParent).addClass("hide").hide();
                        $(_param.idMain).removeClass("hide").show();
                    },

                    init: function (_param) {
                        _param.idParent = (_param.idParent == undefined ? "" : _param.idParent);
                        _param.idMain   = (_param.idMain == undefined ? "" : _param.idMain);
           
                        Util.initClosePanel({
                            id: _param.idMain,
                            hide: true,
                            idHide: _param.idParent
                        }, function () { });
                    }
                }
            },

            addupdate: {
                idContent: ("addupdate-" + SCHUtil.subjectFinanceScholarshipTypeGroupICLSavePeopleApproved.toLowerCase()),

                init: function (_param) {
                    _param.option = (_param.option == undefined ? "" : _param.option);

                    var _this = this;
                    var _data = {};
        
                    Util.textboxDisable("#" + _this.idContent + " input:text");

                    $("#" + _this.idContent + " .button").click(function () {
                        var _idContent = $(this).attr("id");

                        $(this).blur();
           
                        if (_idContent == (_this.idContent + "-btnsave"))
                        {
                            _page = $(this).attr("alt");

                            Util.dialogConfirm({
                                msgTH: "ต้องการบันทึกข้อมูลนี้หรือไม่",
                                msgEN: "Do you want to save changes ?",
                                msgButtonCancelTH: "ยกเลิก",
                                msgButtonCancelEN: "Cancel",
                                msgButtonOKTH: "ตกลง",
                                msgButtonOKEN: "OK"
                            }, function (_result) {
                                if (_result == "Y")
                                {                                    
                                    if (_this.validate())
                                    {
                                        var _selectResult   = new Array();
                                        var _lotNo          = $("#" + Util.tfs.ICL.savePeopleApproved.idContent + "-lotno-hidden").val();

                                        $("#" + Util.tfs.ICL.savePeopleApproved.list.idContent + " table input[name=select-child]" + (_param.option == "selected" ? ":checked" : "")).each(function (_i) {
                                            _data               = {};
                                            _data               = $(this).data("value");
                                            _selectResult[_i]   = (_data.personId + ":" + _data.scholarshipsYear + ":" + _data.semester + ":" + _data.scholarshipsId + ":" + _lotNo);
                                        });

                                        _data           = {};
                                        _data.selected  = _selectResult.join("|");

                                        _this.action({
                                            page: _page,
                                            data: _data,
                                        });
                                    }
                                }
                            });
                        }
                    });
                    
                    _this.reset({
                        option: _param.option
                    });
                },

                reset: function (_param) {
                    _param.option = (_param.option == undefined ? "" : _param.option);

                    var _this = this;
                    var _idContent = ("#" + Util.tfs.ICL.savePeopleApproved.list.idContent + " table" + " .select-child");
                    var _dataCount;
                    var _approveNumberSave;
                    var _approveNumber;
                    var _totalApprove;
                    var _amountsave;
                    var _amount = 0;
                    var _totalAmount;

                    if (_param.option == "selected")    _dataCount = $(_idContent + ":checked").length;
                    if (_param.option == "all")         _dataCount = $(_idContent).length;
        
                    $("#" + _this.idContent + " .view .total").html(_dataCount);
                    $("#" + _this.idContent + " .view .totalcomplete, " +
                      "#" + _this.idContent + " .view .totalincomplete").html("");
                    $("#" + _this.idContent + " .view .totalunit, " +
                      "#" + _this.idContent + " .view .totalunit").hide();

                    _approveNumberSave  = Util.blockCharNotWanted(Util.delCommas("#" + _this.idContent + "-approvenumbersave"));
                    _approveNumberSave  = (_approveNumberSave.length > 0 ? _approveNumberSave : "0");
                    _approveNumber      = _dataCount;
                    _amountsave         = Util.blockCharNotWanted(Util.delCommas("#" + _this.idContent + "-amountsave"));
                    _amountsave         = (_amountsave.length > 0 ? _amountsave : "0");
                    $("#" + Util.tfs.ICL.savePeopleApproved.list.idContent + " table input[name=select-child]" + (_param.option == "selected" ? ":checked" : "")).each(function (_i) {
                        _data           = {};
                        _data           = $(this).data("value");
                        _amount         = (_amount + parseFloat(_data.amount));
                    });
                    _totalApprove       = (parseFloat(_approveNumberSave) + _approveNumber);
                    _totalAmount        = (parseFloat(_amountsave) + _amount);

                    $("#" + _this.idContent + "-approvenumber").val(_approveNumber);
                    Util.addCommas((_this.idContent + "-approvenumber"), 0);
                    $("#" + _this.idContent + "-totalapprove").val(_totalApprove);
                    Util.addCommas((_this.idContent + "-totalapprove"), 0);
                    $("#" + _this.idContent + "-amount").val(_amount);
                    Util.addCommas((_this.idContent + "-amount"), 2);
                    $("#" + _this.idContent + "-totalamount").val(_totalAmount);
                    Util.addCommas((_this.idContent + "-totalamount"), 2);
                },

                validate: function () {
                    var _this = this;
                    var _error = new Array();
                    var _i = 0;
                    var _amountDefault;
                    var _approveNumberDefault;
                    var _totalApprove;
                    var _totalAmount;
                    
                    _approveNumberDefault   = Util.blockCharNotWanted(Util.delCommas("#" + Util.tfs.ICL.savePeopleApproved.idContent + "-approvenumber-hidden"));
                    _amountDefault          = Util.blockCharNotWanted(Util.delCommas("#" + Util.tfs.ICL.savePeopleApproved.idContent + "-amount-hidden"));
                    _totalApprove           = Util.blockCharNotWanted(Util.delCommas("#" + _this.idContent + "-totalapprove"));
                    _totalAmount            = Util.blockCharNotWanted(Util.delCommas("#" + _this.idContent + "-totalamount"));

                    if (parseFloat(_totalApprove) > parseFloat(_approveNumberDefault)) { _error[_i] = ("จำนวนผู้ที่ได้รับอนุมัติที่เลือกมากกว่าจำนวนผู้ที่ได้รับอนุมัติจาก กรอ.;The number of approved persons selected exceeds the number approved by the ICL.;"); _i++; }
                    if (parseFloat(_totalAmount) > parseFloat(_amountDefault)) { _error[_i] = ("จำนวนเงินของผู้ที่ได้รับอนุมัติที่เลือกมากกว่าจำนวนเงินที่ได้รับจาก กรอ.;The amount of approvals selected exceeds the amount received.;"); _i++; }

                    Util.dialogListMessageError({
                        content: _error
                    });

                    return (_i > 0 ? false : true);
                },

                action: function (_param) {
                    _param.page = (_param.page == undefined ? "" : _param.page);
                    _param.data = (_param.data == undefined ? {} : _param.data);

                    var _this = this;
                    var _data = _param.data;
                    var _signinYN = "Y";
                    var _error;            
            
                    _data.signinYN = _signinYN;

                    Util.msgPreloading = "Saving...";
        
                    Util.actionTask({
                        action: "save",
                        page: _param.page,
                        data: _data
                    }, function (_result) {
                        _error = Util.getErrorMsg({
                                    signinYN: _signinYN,
                                    pageError: 0,
                                    cookieError: _result.CookieError,
                                    userError: _result.UserError,
                                    saveError: _result.SaveError
                                 });
            
                        $("#" + _this.idContent + "-saveresult").val(_error == false ? "Y" : "N");

                        if (_error == false)
                        {
                            $("#" + _this.idContent + " .view .totalcomplete").html(_result.Complete);
                            $("#" + _this.idContent + " .view .totalincomplete").html(_result.Incomplete);
                            $("#" + _this.idContent + " .view .totalunit, " +
                              "#" + _this.idContent + " .view .totalunit").show();

                            Util.dialogMessage({
                                type: "info",
                                msgTH: "บันทึกข้อมูลเรียบร้อย",
                                msgEN: "Save complete."
                            }, function (_result) {
                                $(".dialogform .btnclose").click();
                            });
                        }
                    });
                }
            }
        },

        classificationRecipientFinance: {
            idContent: ("main-" + SCHUtil.subjectFinanceScholarshipTypeGroupICLClassificationRecipientFinance.toLowerCase()),

            init: function () {
                var _this = this;                

                _this.search.init();
            },

            search: {
                idContent: ("search-" + SCHUtil.subjectFinanceScholarshipTypeGroupICLClassificationRecipientFinance.toLowerCase()),

                init: function () {
                    var _this = this;

                    Util.initShrinkPanel({
                        id: ("#" + _this.idContent)
                    });                    
                    Util.initDropdown({
                        id: ("#" + _this.idContent)
                    }, function (_result) {
                        Util.tfs.ICL.classificationRecipientFinance.list.clear();
                    });
                    
                    $("#" + _this.idContent + " .button").click(function () {
                        var _idContent = $(this).attr("id");

                        $(this).blur();

                        if (_idContent == (_this.idContent + "-btnsearch"))
                        {
                            if (_this.validate())
                                _this.action(function () {
                                    Util.gotoElement({
                                        anchorName: ("#" + Util.tfs.ICL.classificationRecipientFinance.list.idContent),
                                        top: ($("#followingmenu").outerHeight())
                                    });
                                });
                        }
                    });
                },
                
                validate: function () {
                    var _this = this;
                    var _error = new Array();
                    var _scholarshipsYearSemester = Util.getDropdrownValue({ id: ("#" + _this.idContent + "-scholarshipsyearsemester") });
                    var _i = 0;

                    if (_scholarshipsYearSemester == "0") { _error[_i] = ("กรุณาเลือกปี / ภาคเรียนที่อนุมัติรับเงิน;Please select approval receive finance on year / semester.;"); _i++; }

                    Util.dialogListMessageError({
                        content: _error
                    });

                    return (_i > 0 ? false : true);        
                },

                value: function () {
                    var _this = this;
                    var _data = {};
                    var _scholarshipsYearSemester   = Util.getSelectionIsSelect({
                                                        id: ("#" + _this.idContent + "-scholarshipsyearsemester"),
                                                        type: "select",
                                                        valueTrue: Util.getDropdrownValue({
                                                                        id: ("#" + _this.idContent + "-scholarshipsyearsemester")
                                                                   })
                                                      });

                    _data.keyword               = $("#main-keyword").val();
                    _data.facultyId             = Util.getSelectionIsSelect({
                                                    id: ("#" + _this.idContent + "-faculty"),
                                                    type: "select",
                                                    valueTrue: Util.getDropdrownValue({
                                                                    id: ("#" + _this.idContent + "-faculty")
                                                               })
                                                  });
                    _data.programId             = Util.getSelectionIsSelect({
                                                    id: ("#" + _this.idContent + "-program"),
                                                    type: "select",
                                                    valueTrue: Util.getDropdrownValue({
                                                                    id: ("#" + _this.idContent + "-program")
                                                               })
                                                  });
                    _data.yearEntry             = Util.getSelectionIsSelect({
                                                    id: ("#" + _this.idContent + "-yearentry"),
                                                    type: "select",
                                                    valueTrue: Util.getDropdrownValue({
                                                                    id: ("#" + _this.idContent + "-yearentry")
                                                               })
                                                  });
                    _data.scholarshipsTypeGroup = Util.subjectICL;
                    _data.scholarshipsYear      = (_scholarshipsYearSemester.length > 0 ? _scholarshipsYearSemester.split(":")[0] : "");
                    _data.semester              = (_scholarshipsYearSemester.length > 0 ? _scholarshipsYearSemester.split(":")[1] : "");
                    _data.lotNo                 = Util.getSelectionIsSelect({
                                                    id: ("#" + _this.idContent + "-lotno"),
                                                    type: "select",
                                                    valueTrue: Util.getDropdrownValue({
                                                                    id: ("#" + _this.idContent + "-lotno")
                                                               })
                                                  });
                    _data.groupReceiver         = Util.getSelectionIsSelect({
                                                    id: ("#" + _this.idContent + "-groupreceiver"),
                                                    type: "select",
                                                    valueTrue: Util.getDropdrownValue({
                                                                    id: ("#" + _this.idContent + "-groupreceiver")
                                                               })
                                                  });
                    _data.recipientStatus       = Util.getSelectionIsSelect({
                                                    id: ("#" + _this.idContent + "-recipientstatus"),
                                                    type: "select",
                                                    valueTrue: Util.getDropdrownValue({
                                                                    id: ("#" + _this.idContent + "-recipientstatus")
                                                               })
                                                  });

                    return _data;
                },
                
                action: function (_callBackFunc) {
                    var _this = this;
                    var _data = {};
       
                    Util.tfs.ICL.classificationRecipientFinance.list.clear();

                    _data = _this.value();

                    Util.msgPreloading = "Searching...";

                    Util.actionTask({
                        action: "search",
                        page: Util.pageFinanceScholarshipTypeGroupICLClassificationRecipientFinanceMain,
                        data: _data
                    }, function (_result) {
                        $("#" + Util.tfs.ICL.classificationRecipientFinance.list.idContent).html(_result.List);
                        $("#" + Util.tfs.ICL.classificationRecipientFinance.list.idContent + " .recordcountprimary-search").html(_result.RecordCountPrimary);
                        $("#" + Util.tfs.ICL.classificationRecipientFinance.list.idContent + " .sum-search").html(_result.Sum);
                        $("#" + Util.tfs.ICL.classificationRecipientFinance.list.idContent + " .table-navpage").html(_result.NavPage);

                        Util.setBodyLayout();
                        Util.setLanguageOnForm({
                            id: ("#" + Util.tfs.ICL.classificationRecipientFinance.list.idContent)
                        });

                        Util.tfs.ICL.classificationRecipientFinance.list.init();
                        _callBackFunc();
                    });
                }
            },

            list: {
                idContent: ("list-" + SCHUtil.subjectFinanceScholarshipTypeGroupICLClassificationRecipientFinance.toLowerCase()),

                init: function () {
                    var _this = this;
                    var _i;

                    Util.initCheck({
                        id: ("#" + _this.idContent + " .checkbox")
                    });
                    for (_i = 0; _i < $("#" + _this.idContent + " table thead th").length; _i++)
                    {
                        Util.initTooltip({
                            id: ("#" + _this.idContent + " table td.col" + (_i + 1))
                        });
                    }
                    Util.initTable({
                        id: ("#" + _this.idContent + " table")
                    });

                    $("#" + _this.idContent + " .button").click(function () {
                        var _data = {};
                        var _idContent;
                        
                        $(this).blur();

                        if ($(this).hasClass("btnstudentcv"))
                        {
                            _data = $(this).data("value");

                            Util.tfs.ICL.studentCV.form({
                                data: _data,
                                idParent: _this.idContent,
                                idMain: Util.tfs.ICL.classificationRecipientFinance.idContent
                            });
                        }
                    });
                    
                    $("#" + _this.idContent + " .btnsave-option").click(function () {
                        var _option = $(this).attr("alt");
                        var _scholarshipsTypeGroup;
                        var _scholarshipsYear;
                        var _semester;
                        var _lotNo;

                        $(this).blur();

                        if (_this.option.save.validate({
                                option: _option
                            }))
                        {
                            Util.loadForm({
                                name: Util.pageFinanceScholarshipTypeGroupICLClassificationRecipientFinanceAddUpdate,
                                dialog: true,
                            }, function (_result, _e) {
                                if (_result.MainContent.length > 0)
                                    Util.tfs.ICL.classificationRecipientFinance.addupdate.init({
                                        option: _option,
                                    });
                            });
                        }
                    });                    
                },

                clear: function () {
                    var _this = this;

                    $("#" + _this.idContent).html("");
                    Util.setBodyLayout();
                },

                option: {
                    save: {
                        validate: function (_param) {
                            _param.option = (_param.option == undefined ? "" : _param.option);

                            var _this = this;
                            var _error = false;
                            var _msgTH;
                            var _msgEN;
                            var _idContent = ("#" + Util.tfs.ICL.classificationRecipientFinance.idContent + " table" + " .select-child");

                            if (_error == false && _param.option == "all" && $(_idContent).length == 0) { _error = true; _msgTH = "ไม่พบข้อมูล"; _msgEN = "Data not found."; }
                            if (_error == false && _param.option == "selected" && $(_idContent + ":checked").length == 0) { _error = true; _msgTH = "กรุณาเลือกรายการ"; _msgEN = "Please select item."; }

                            if (_error == true)
                            {
                                Util.dialogMessage({
                                    type: "danger",
                                    msgTH: _msgTH,
                                    msgEN: _msgEN
                                }, function (_result) { });

                                return false;
                            }

                            return true;
                        }
                    }
                }
            },

            addupdate: {
                idContent: ("addupdate-" + SCHUtil.subjectFinanceScholarshipTypeGroupICLClassificationRecipientFinance.toLowerCase()),

                init: function (_param) {
                    _param.option = (_param.option == undefined ? "" : _param.option);

                    var _this = this;
                    var _data = {};
        
                    Util.textboxDisable("#" + _this.idContent + " input:text");

                    $("#" + _this.idContent + " .button").click(function () {
                        var _idContent = $(this).attr("id");

                        $(this).blur();
           
                        if (_idContent == (_this.idContent + "-btnsave"))
                        {
                            _page = $(this).attr("alt");

                            Util.dialogConfirm({
                                msgTH: "ต้องการบันทึกข้อมูลนี้หรือไม่",
                                msgEN: "Do you want to save changes ?",
                                msgButtonCancelTH: "ยกเลิก",
                                msgButtonCancelEN: "Cancel",
                                msgButtonOKTH: "ตกลง",
                                msgButtonOKEN: "OK"
                            }, function (_result) {
                                if (_result == "Y")
                                {                                    
                                    if (_this.validate())
                                    {
                                        var _selectResult = new Array();

                                        if (_param.option == "selected")
                                        {
                                            $("#" + Util.tfs.ICL.classificationRecipientFinance.list.idContent + " table input[name=select-child]:checked").each(function (_i) {
                                                _data               = {};
                                                _data               = $(this).data("value");
                                                _selectResult[_i]   = (_data.personId + ":" + _data.scholarshipsYear + ":" + _data.semester + ":" + _data.scholarshipsId + ":" + _data.groupReceiverId);
                                            });

                                            _selected       = _selectResult.join("|");
                                            _paramSearch    = "";
                                        }

                                        if (_param.option == "all")
                                        {
                                            _selected = "";
                                            _paramSearch = (JSON.stringify(Util.tfs.ICL.classificationRecipientFinance.search.value())).replace(/({|}|")/g, "");
                                        }

                                        _data               = {};
                                        _data.option        = _param.option;
                                        _data.selected      = _selected;
                                        _data.paramSearch   = _paramSearch;

                                        _this.action({
                                            page: _page,
                                            data: _data,
                                        });
                                    }
                                }
                            });
                        }
                    });

                    _this.reset({
                        option: _param.option
                    });
                },

                reset: function (_param) {
                    _param.option = (_param.option == undefined ? "" : _param.option);

                    var _this = this;
                    var _recordCount = ($("#" + Util.tfs.ICL.classificationRecipientFinance.list.idContent + " .table-title .recordcountprimary-search").length > 0 ? $("#" + Util.tfs.ICL.classificationRecipientFinance.list.idContent + " .table-title .recordcountprimary-search:eq(0)").html() : "");
                    var _idContent = ("#" + Util.tfs.ICL.classificationRecipientFinance.list.idContent + " table" + " .select-child");
                    var _dataCount;
                    var _recipientNumber;
                    var _amount = 0;
                    
                    if (_param.option == "selected")
                    {
                        _dataCount  = $(_idContent + ":checked").length;
                        $("#" + Util.tfs.ICL.classificationRecipientFinance.list.idContent + " table input[name=select-child]:checked").each(function (_i) {
                            _data   = {};
                            _data   = $(this).data("value");
                            _amount = (_amount + parseFloat(_data.amount));
                        });
                        _amount     = _amount.toLocaleString(undefined, {
                                        minimumFractionDigits: 2,
                                        maximumFractionDigits: 2
                                      });
                    }                        
                    if (_param.option == "all")
                    {
                        _dataCount  = (_recordCount.length > 0 && _recordCount != "0" ? _recordCount : "0");
                        _amount     =  $("#" + Util.tfs.ICL.classificationRecipientFinance.list.idContent + " .sum-search").html();
                    }
        
                    $("#" + _this.idContent + " .view .total").html(_dataCount);
                    $("#" + _this.idContent + " .view .totalcomplete, " +
                      "#" + _this.idContent + " .view .totalincomplete").html("");
                    $("#" + _this.idContent + " .view .totalunit, " +
                      "#" + _this.idContent + " .view .totalunit").hide();

                    _recipientNumber = _dataCount;
                    
                    $("#" + _this.idContent + "-recipientnumber").val(_recipientNumber);
                    $("#" + _this.idContent + "-amount").val(_amount);
                },

                validate: function () {
                    var _this = this;
                    var _error = new Array();
                    var _i = 0;

                    return (_i > 0 ? false : true);
                },

                action: function (_param) {
                    _param.page = (_param.page == undefined ? "" : _param.page);
                    _param.data = (_param.data == undefined ? {} : _param.data);

                    var _this = this;
                    var _data = _param.data;
                    var _signinYN = "Y";
                    var _error;            
            
                    _data.signinYN = _signinYN;

                    Util.msgPreloading = "Saving...";
            
                    Util.actionTask({
                        action: "save",
                        page: _param.page,
                        data: _data
                    }, function (_result) {
                        _error = Util.getErrorMsg({
                                    signinYN: _signinYN,
                                    pageError: 0,
                                    cookieError: _result.CookieError,
                                    userError: _result.UserError,
                                    saveError: _result.SaveError
                                 });

                        $("#" + _this.idContent + "-saveresult").val(_error == false ? "Y" : "N");

                        if (_error == false)
                        {
                            $("#" + _this.idContent + " .view .totalcomplete").html(_result.Complete);
                            $("#" + _this.idContent + " .view .totalincomplete").html(_result.Incomplete);
                            $("#" + _this.idContent + " .view .totalunit, " +
                              "#" + _this.idContent + " .view .totalunit").show();

                            Util.dialogMessage({
                                type: "info",
                                msgTH: "บันทึกข้อมูลเรียบร้อย",
                                msgEN: "Save complete."
                            }, function (_result) {
                                $(".dialogform .btnclose").click();
                            });
                        }
                    });
                }
            }
        },

        payCheque: {
            idContent: ("main-" + SCHUtil.subjectFinanceScholarshipTypeGroupICLPayCheque.toLowerCase()),
            firstLoad: true,

            init: function () {
                var _this = this;                

                $("#" + _this.idContent + " .button").click(function () {
                    var _idContent = $(this).attr("id");

                    $(this).blur();

                    if (_idContent == (_this.idContent + "-btnadd"))
                    {
                        Util.loadForm({
                            name: Util.pageFinanceScholarshipTypeGroupICLPayChequeAdd,
                            id: ("#" + _this.addupdate.idContent)
                        }, function (_result) {
                            _this.addupdate.init({
                                page: Util.pageFinanceScholarshipTypeGroupICLPayChequeAdd
                            });
                        });
                    }
                });

                _this.search.init();
                $("#" + _this.search.idContent + "-btnsearch").click();
            },

            search: {
                idContent: ("search-" + SCHUtil.subjectFinanceScholarshipTypeGroupICLPayCheque.toLowerCase()),                

                init: function () {
                    var _this = this;

                    Util.initShrinkPanel({
                        id: ("#" + _this.idContent)
                    });
                    Util.initDropdown({
                        id: ("#" + _this.idContent)
                    }, function (_result) {
                        Util.tfs.ICL.payCheque.list.clear();
                    });
                    
                    $("#" + _this.idContent + " .button").click(function () {
                        var _idContent = $(this).attr("id");

                        $(this).blur();

                        if (_idContent == (_this.idContent + "-btnsearch"))
                        {
                            if (_this.validate())
                            {
                                _this.action(function () {
                                    if (Util.tfs.ICL.payCheque.firstLoad == false)
                                    {
                                        Util.gotoElement({
                                            anchorName: ("#" + Util.tfs.ICL.payCheque.list.idContent),
                                            top: ($("#followingmenu").outerHeight())
                                        });
                                    }

                                    Util.tfs.ICL.payCheque.firstLoad = false;
                                });
                            }
                        }
                    });                    
                },

                validate: function () {
                    var _error = false;
                    var _msgTH;
                    var _msgEN;
 
                    return (_error == false ? true : false);
                },
            
                value: function () {
                    var _this = this;
                    var _data = {};
                    var _payChequeYearSemester = Util.getSelectionIsSelect({
                                                    id: ("#" + _this.idContent + "-paychequeyearsemester"),
                                                    type: "select",
                                                    valueTrue: Util.getDropdrownValue({
                                                                    id: ("#" + _this.idContent + "-paychequeyearsemester")
                                                               })
                                                  });

                    _data.scholarshipsTypeGroup = Util.subjectICL;
                    _data.payChequeYear         = (_payChequeYearSemester.length > 0 ? _payChequeYearSemester.split(":")[0] : "");
                    _data.semester              = (_payChequeYearSemester.length > 0 ? _payChequeYearSemester.split(":")[1] : "");

                    return _data;
                },
                
                action: function (_callBackFunc) {
                    var _this = this;
                    var _data = {};
       
                    Util.tfs.ICL.payCheque.list.clear();

                    _data = _this.value();

                    Util.msgPreloading = "Searching...";

                    Util.actionTask({
                        action: "search",
                        page: Util.pageFinanceScholarshipTypeGroupICLPayChequeMain,
                        data: _data
                    }, function (_result) {
                        $("#" + Util.tfs.ICL.payCheque.list.idContent).html(_result.List);
                        $("#" + Util.tfs.ICL.payCheque.list.idContent + " .recordcountprimary-search").html(_result.RecordCountPrimary);
                        $("#" + Util.tfs.ICL.payCheque.list.idContent + " .table-navpage").html(_result.NavPage);

                        Util.setBodyLayout();
                        Util.setLanguageOnForm({
                            id: ("#" + Util.tfs.ICL.payCheque.list.idContent)
                        });

                        Util.tfs.ICL.payCheque.list.init();
                        _callBackFunc();
                    });
                }
            },

            list: {
                idContent: ("list-" + SCHUtil.subjectFinanceScholarshipTypeGroupICLPayCheque.toLowerCase()),

                init: function () {
                    var _this = this;
                    var _i;
                    
                    for (_i = 0; _i < $("#" + _this.idContent + " table thead th").length; _i++)
                    {
                        Util.initTooltip({
                            id: ("#" + _this.idContent + " table td.col" + (_i + 1))
                        });
                    }
                    Util.initTable({
                        id: ("#" + _this.idContent + " table")
                    });
                    
                    $("#" + _this.idContent + " .button").click(function () {
                        var _idContent;

                        $(this).blur();

                        if ($(this).hasClass("btnupdate"))
                        {
                            Util.loadForm({
                                name: Util.pageFinanceScholarshipTypeGroupICLPayChequeUpdate,
                                data: $(this).data("value"),
                                id: ("#" + Util.tfs.ICL.payCheque.addupdate.idContent)
                            }, function (_result) {                            
                                if (_result.MainContent.length > 0)
                                    Util.tfs.ICL.payCheque.addupdate.init({
                                        page: Util.pageFinanceScholarshipTypeGroupICLPayChequeUpdate
                                    });
                            });
                        }
                    });
                    
                    $("#" + _this.idContent + " .link-click").click(function () {
                        if ($(this).hasClass("link-savepeoplepaycheque"))
                        {
                            var _data = $(this).data("value");

                            Util.loadForm({
                                name: Util.pageFinanceScholarshipTypeGroupICLSavePeoplePayChequeMain,
                                data: (_data.payChequeYear + "|" + _data.semester + "|" + _data.lotNo + "|" + _data.PVJVNo + "|" + _data.chequeNo),
                                id: ("#" + Util.tfs.ICL.savePeoplePayCheque.idContent)
                            }, function (_result) {
                                if (_result.MainContent.length > 0)
                                {
                                    $("." + Util.tfs.ICL.payCheque.idContent).hide();
                                    $("#" + Util.tfs.ICL.savePeoplePayCheque.idContent).show();
                                    $("#main-quicksearch").removeClass("hide");
                                    $("#main-keyword").val("");
                                    Util.setBodyLayout();
                                    Util.gotoTopElement();

                                    Util.tfs.ICL.savePeoplePayCheque.firstLoad = true;
                                    Util.tfs.ICL.savePeoplePayCheque.init();
                                    Util.tfs.ICL.savePeoplePayCheque.search.init();
                                    $("#" + Util.tfs.ICL.savePeoplePayCheque.search.idContent + "-btnsearch").click();
                                }
                            });
                        }
                    });
                },

                clear: function () {
                    var _this = this;

                    $("#" + Util.tfs.ICL.payCheque.addupdate.idContent).html("");
                    $("#" + _this.idContent).html("");
                    Util.setBodyLayout();
                }
            },

            addupdate: {
                idContent: ("addupdate-" + SCHUtil.subjectFinanceScholarshipTypeGroupICLPayCheque.toLowerCase()),

                init: function (_param) {
                    _param.page = (_param.page == undefined ? "" : _param.page);

                    var _this = this;
                    var _page;

                    Util.initClosePanel({
                        id: ("#" + _this.idContent)
                    }, function () { });
                    Util.initDropdown({
                        id: ("#" + _this.idContent)
                    }, function (_result) {
                    });
                    Util.initCalendar({
                        id: ("#" + _this.idContent + "-preparedate")
                    });
                    Util.initCalendar({
                        id: ("#" + _this.idContent + "-paiddate")
                    });
                    if (_param.page == Util.pageFinanceScholarshipTypeGroupICLPayChequeUpdate)
                    {
                        $("#" + _this.idContent + "-paychequeyearsemester").addClass("disabled");
                        Util.textboxDisable("#" + _this.idContent + "-lotno");
                        Util.textboxDisable("#" + _this.idContent + "-pvjvno");
                        Util.textboxDisable("#" + _this.idContent + "-chequeno");
                    }                    
                    
                    $("#" + _this.idContent + " .textbox-numeric").keyup(function () {
                        var _idContent = $(this).attr("id");

                        if (_idContent == (_this.idContent + "-amount"))            return Util.extractNumber(this, 2, false);
                        if (_idContent == (_this.idContent + "-receivernumber"))    return Util.extractNumber(this, 0, false);
                    });                    
                    $("#" + _this.idContent + " .textbox-numeric").keypress(function (_e) {
                        var _idContent = $(this).attr("id");

                        if (_idContent == (_this.idContent + "-lotno"))             return Util.blockNonNumbers(this, _e, true, false);
                        if (_idContent == (_this.idContent + "-pvjvno"))            return Util.blockNonEnglishAndNumeric(this, _e);
                        if (_idContent == (_this.idContent + "-chequeno"))          return Util.blockNonEnglishAndNumeric(this, _e);
                        if (_idContent == (_this.idContent + "-amount"))            return Util.blockNonNumbers(this, _e, true, false);
                        if (_idContent == (_this.idContent + "-receivernumber"))    return Util.blockNonNumbers(this, _e, true, false);

                        return Util.blockNonNumbers(this, _e, true, false);
                    });
                    $("#" + _this.idContent + " .textbox-numeric").focusout(function () {
                        var _idContent = $(this).attr("id");
                        var _decimalPlaces;
                        var _maxLength;

                        if (_idContent == (_this.idContent + "-amount") ||
                            _idContent == (_this.idContent + "-receivernumber"))
                        {
                            if (_idContent == (_this.idContent + "-amount"))
                            {
                                _decimalPlaces  = 2;
                                _maxLength      = 13;
                            }
                            if (_idContent == (_this.idContent + "-receivernumber"))
                            {
                                _decimalPlaces  = 0;
                                _maxLength      = 5;
                            }

                            Util.addCommas(_idContent, _decimalPlaces);
                            ($(this).val($(this).val().length > _maxLength ? $(this).val().substring($(this).val().length, $(this).val().length - _maxLength) : $(this).val()));
                            $(this).val(Util.delCommas("#" + _idContent));
                            Util.addCommas(_idContent, _decimalPlaces);
                            $(this).val(Util.blockCharNotWanted($(this).val()));
                        }
                    });
                    
                    $("#" + _this.idContent + " .button").click(function () {
                        var _idContent = $(this).attr("id");

                        $(this).blur();

                        if (_idContent == (_this.idContent + "-btnsave"))
                        {                               
                            _page = $(this).attr("alt");

                            Util.dialogConfirm({
                                msgTH: "ต้องการบันทึกข้อมูลนี้หรือไม่",
                                msgEN: "Do you want to save changes ?",
                                msgButtonCancelTH: "ยกเลิก",
                                msgButtonCancelEN: "Cancel",
                                msgButtonOKTH: "ตกลง",
                                msgButtonOKEN: "OK"
                            }, function (_result) {
                                if (_result == "Y")
                                {
                                    if (_this.validate())
                                        _this.action({
                                            page: _page,
                                            data: _this.value()
                                        });
                                }
                            });
                        }
                    });

                    _this.reset({
                        page: _param.page
                    });
                },

                reset: function (_param) {
                    _param.page = (_param.page == undefined ? "" : _param.page);

                    var _this = this;

                    Util.gotoElement({
                        anchorName: ("#" + _this.idContent),
                        top: ($("#followingmenu").outerHeight())
                    });
                    
                    $("#" + _this.idContent + "-paychequeyearsemester").dropdown("set selected", ($("#" + _this.idContent + "-paychequeyear-hidden").val() + ":" + $("#" + _this.idContent + "-semester-hidden").val()));
                    $("#" + _this.idContent + "-lotno").val($("#" + _this.idContent + "-lotno-hidden").val());
                    $("#" + _this.idContent + "-pvjvno").val($("#" + _this.idContent + "-pvjvno-hidden").val());
                    $("#" + _this.idContent + "-chequeno").val($("#" + _this.idContent + "-chequeno-hidden").val());
                    $("#" + _this.idContent + "-groupreceiver").dropdown("set selected", $("#" + _this.idContent + "-groupreceiver-hidden").val());
                    $("#" + _this.idContent + "-bankcode").dropdown("set selected", $("#" + _this.idContent + "-bankcode-hidden").val());
                    $("#" + _this.idContent + "-amount").val($("#" + _this.idContent + "-amount-hidden").val());
                    $("#" + _this.idContent + "-receivernumber").val($("#" + _this.idContent + "-receivernumber-hidden").val());
                    Util.setCalendarValue({
                        id: ("#" + _this.idContent + "-preparedate"),
                        value: $("#" + _this.idContent + "-preparedate-hidden").val()
                    });
                    Util.setCalendarValue({
                        id: ("#" + _this.idContent + "-paiddate"),
                        value: $("#" + _this.idContent + "-paiddate-hidden").val()
                    });
                },

                validate: function () {
                    var _this = this;
                    var _error = new Array();
                    var _payChequeYearSemester = Util.getDropdrownValue({ id: ("#" + _this.idContent + "-paychequeyearsemester") });
                    var _lotNo = $("#" + _this.idContent + "-lotno").val();
                    var _pvjvNo = $("#" + _this.idContent + "-pvjvno").val();
                    var _chequeNo = $("#" + _this.idContent + "-chequeno").val();
                    var _groupReceiver = Util.getDropdrownValue({ id: ("#" + _this.idContent + "-groupreceiver") });
                    var _amount = Util.delCommas("#" + _this.idContent + "-amount");
                    var _receiverNumber = Util.delCommas("#" + _this.idContent + "-receivernumber");
                    var _paidDate = Util.getCalendarValue({ id: ("#" + _this.idContent + "-paiddate") });
                    var _i = 0;

                    if (_payChequeYearSemester == "0")  { _error[_i] = ("กรุณาเลือกปี / ภาคเรียนที่จ่ายเช็ค ;Please select pay cheque on year / semester.;"); _i++; }
                    if (_lotNo.length == 0)             { _error[_i] = ("กรุณาระบุงวดที่จ่าย / โอน;Please enter pay period."); _i++; }
                    if (_pvjvNo.length == 0)            { _error[_i] = ("กรุณาระบุเลขที่ PV / JV;Please enter PV / JV no."); _i++; }
                    if (_chequeNo.length == 0)          { _error[_i] = ("กรุณาระบุเลขที่เช็ค;Please enter cheque no."); _i++; }
                    if (_groupReceiver == "0")          { _error[_i] = ("กรุณาเลือกผู้รับเงิน;Please select group receiver."); _i++; }
                    if (_amount.length == 0)            { _error[_i] = ("กรุณาระบุจำนวนเงิน;Please enter amount."); _i++; }
                    if (_receiverNumber.length == 0)    { _error[_i] = ("กรุณาระบุจำนวนผู้รับเงิน;Please enter number of recipient."); _i++; }
                    if (_paidDate.length == 0)          { _error[_i] = ("กรุณาระบุวันที่จ่ายเช็ค;Please enter date of pay cheque.;"); _i++; }

                    Util.dialogListMessageError({
                        content: _error
                    });

                    return (_i > 0 ? false : true);
                },

                value: function () {
                    var _this = this;
                    var _data = {};
                    var _payChequeYearSemester  = Util.getSelectionIsSelect({
                                                        id: ("#" + _this.idContent + "-paychequeyearsemester"),
                                                        type: "select",
                                                        valueTrue: Util.getDropdrownValue({
                                                                        id: ("#" + _this.idContent + "-paychequeyearsemester")
                                                                   })
                                                      });

                    _data.id                = $("#" + _this.idContent + "-id-hidden").val();
                    _data.payChequeYear     = (_payChequeYearSemester.length > 0 ? _payChequeYearSemester.split(":")[0] : "");
                    _data.semester          = (_payChequeYearSemester.length > 0 ? _payChequeYearSemester.split(":")[1] : "");
                    _data.lotno             = $("#" + _this.idContent + "-lotno").val();
                    _data.pvjvNo            = $("#" + _this.idContent + "-pvjvno").val();
                    _data.chequeNo          = $("#" + _this.idContent + "-chequeno").val();
                    _data.groupReceiver     = Util.getSelectionIsSelect({
                                                id: ("#" + _this.idContent + "-groupreceiver"),
                                                type: "select",
                                                valueTrue: Util.getDropdrownValue({
                                                                id: ("#" + _this.idContent + "-groupreceiver")
                                                           })
                                              });
                    _data.bankCode          = Util.getSelectionIsSelect({
                                                id: ("#" + _this.idContent + "-bankcode"),
                                                type: "select",
                                                valueTrue: Util.getDropdrownValue({
                                                                id: ("#" + _this.idContent + "-bankcode")
                                                           })
                                              });
                    _data.amount            = Util.delCommas("#" + _this.idContent + "-amount");
                    _data.receiverNumber    = Util.delCommas("#" + _this.idContent + "-receivernumber");
                    _data.prepareDate       = Util.getCalendarValue({ id: ("#" + _this.idContent + "-preparedate") });
                    _data.paidDate          = Util.getCalendarValue({ id: ("#" + _this.idContent + "-paiddate") });

                    return _data;
                },
                
                action: function (_param) {
                    _param.page = (_param.page == undefined ? "" : _param.page);
                    _param.data = (_param.data == undefined ? {} : _param.data);

                    var _this = this;
                    var _data = _param.data;
                    var _signinYN = "Y";
                    var _error;                    
                    
                    _data.signinYN = _signinYN;

                    Util.msgPreloading = "Saving...";
        
                    Util.actionTask({
                        action: "save",
                        page: _param.page,
                        data: _data
                    }, function (_result) {
                        if (_result.Action == "INSERT" && _result.SaveError == "1") _result.SaveError = "5"

                        _error = Util.getErrorMsg({
                                    signinYN: _signinYN,
                                    pageError: 0,
                                    cookieError: _result.CookieError,
                                    userError: _result.UserError,
                                    saveError: _result.SaveError
                                 });

                        if (_error == false)
                        {                
                            Util.dialogMessage({
                                type: "info",
                                msgTH: "บันทึกข้อมูลเรียบร้อย",
                                msgEN: "Save complete."
                            }, function (_result) {
                                $("#" + _this.idContent + " .btnclose").click();

                                Util.gotoNavPage({
                                    page: Util.pageFinanceScholarshipTypeGroupICLPayChequeMain,
                                    currentPage: Util.currentPage,
                                    startRow: Util.startRow,
                                    endRow: Util.endRow
                                });
                            });
                        }
                    });
                }
            }
        },

        savePeoplePayCheque: {
            idContent: ("main-" + SCHUtil.subjectFinanceScholarshipTypeGroupICLSavePeoplePayCheque.toLowerCase()),
            firstLoad: true,
            
            init: function () {
                var _this = this;

                Util.initClosePanel({
                    id: ("#" + _this.idContent),
                    hide: true,
                    idHide: ("#" + _this.idContent),
                    show: true,
                    idShow: ("." + Util.tfs.ICL.payCheque.idContent)
                }, function () {
                    $("body").css("min-width", "765px");
                    $("#main-quicksearch").addClass("hide");
                    
                    Util.gotoNavPage({
                        page: Util.pageFinanceScholarshipTypeGroupICLPayChequeMain,
                        currentPage: Util.currentPage,
                        startRow: Util.startRow,
                        endRow: Util.endRow
                    });
                });
            },

            search: {
                idContent: ("search-" + SCHUtil.subjectFinanceScholarshipTypeGroupICLSavePeoplePayCheque.toLowerCase()),

                init: function () {
                    var _this = this;

                    Util.initDropdown({
                        id: ("#" + _this.idContent)
                    }, function (_result) {
                        Util.tfs.ICL.savePeoplePayCheque.list.clear();
                    });

                    $("#" + _this.idContent + " .button").click(function () {
                        var _idContent = $(this).attr("id");

                        $(this).blur();

                        if (_idContent == (_this.idContent + "-btnsearch"))
                        {
                            if (_this.validate())
                                _this.action(function () {
                                    if (Util.tfs.ICL.savePeoplePayCheque.firstLoad == false)
                                    {
                                        Util.gotoElement({
                                            anchorName: ("#" + Util.tfs.ICL.savePeoplePayCheque.list.idContent),
                                            top: ($("#followingmenu").outerHeight())
                                        });
                                    }

                                    Util.tfs.ICL.savePeoplePayCheque.firstLoad = false
                                });
                        }
                    });
                },
                
                validate: function () {
                    var _error = false;
                    var _msgTH;
                    var _msgEN;
 
                    return (_error == false ? true : false);
                },

                value: function () {
                    var _this = this;
                    var _data = {}

                    _data.payChequeYear     = $("#" + Util.tfs.ICL.savePeoplePayCheque.idContent + "-paychequeyear-hidden").val();
                    _data.semester          = $("#" + Util.tfs.ICL.savePeoplePayCheque.idContent + "-semester-hidden").val();
                    _data.lotNo             = $("#" + Util.tfs.ICL.savePeoplePayCheque.idContent + "-lotno-hidden").val();
                    _data.pvjvNo            = $("#" + Util.tfs.ICL.savePeoplePayCheque.idContent + "-pvjvno-hidden").val();
                    _data.chequeNo          = $("#" + Util.tfs.ICL.savePeoplePayCheque.idContent + "-chequeno-hidden").val();
                    _data.groupReceiver     = $("#" + Util.tfs.ICL.savePeoplePayCheque.idContent + "-groupreceiver-hidden").val();
                    _data.bankId            = $("#" + Util.tfs.ICL.savePeoplePayCheque.idContent + "-bankid-hidden").val();
                    _data.keyword           = $("#main-keyword").val();
                    _data.payChequeStatus   = Util.getSelectionIsSelect({
                                                id: ("#" + _this.idContent+ "-paychequestatus"),
                                                type: "select",
                                                valueTrue: Util.getDropdrownValue({
                                                                id: ("#" + _this.idContent + "-paychequestatus")
                                                            })
                                              });

                    return _data;
                },                

                action: function (_callBackFunc) {
                    var _this = this;
                    var _data = {};
       
                    Util.tfs.ICL.savePeoplePayCheque.list.clear();

                    _data = _this.value();
                   
                    Util.msgPreloading = "Searching...";

                    Util.actionTask({
                        action: "search",
                        page: Util.pageFinanceScholarshipTypeGroupICLSavePeoplePayChequeMain,
                        data: _data
                    }, function (_result) {
                        $("#" + Util.tfs.ICL.savePeoplePayCheque.list.idContent).html(_result.List);
                        $("#" + Util.tfs.ICL.savePeoplePayCheque.list.idContent + " .recordcountprimary-search").html(_result.RecordCountPrimary);
                        $("#" + Util.tfs.ICL.savePeoplePayCheque.list.idContent + " .sum-search").html(_result.Sum);

                        Util.setBodyLayout();
                        Util.setLanguageOnForm({
                            id: ("#" + Util.tfs.ICL.savePeoplePayCheque.list.idContent)
                        });

                        Util.tfs.ICL.savePeoplePayCheque.list.init();
                        _callBackFunc();
                    });
                }
            },

            list: {
                idContent: ("list-" + SCHUtil.subjectFinanceScholarshipTypeGroupICLSavePeoplePayCheque.toLowerCase()),

                init: function () {
                    var _this = this;
                    var _i;
                    
                    Util.initCheck({
                        id: ("#" + _this.idContent + " .checkbox")
                    });
                    for (_i = 0; _i < $("#" + _this.idContent + " table thead th").length; _i++)
                    {
                        Util.initTooltip({
                            id: ("#" + _this.idContent + " table td.col" + (_i + 1))
                        });
                    }
                    Util.initTable({
                        id: ("#" + _this.idContent + " table")
                    });
                    
                    $("#" + _this.idContent + " .button").click(function () {
                        var _data = {};
                        var _idContent;
                        
                        $(this).blur();

                        if ($(this).hasClass("btnstudentcv"))
                        {
                            _data = $(this).data("value");

                            Util.tfs.ICL.studentCV.form({
                                data: _data,
                                idParent: _this.idContent,
                                idMain: Util.tfs.ICL.savePeoplePayCheque.idContent
                            });
                        }
                    });
                    
                    $("#" + _this.idContent + " .btnsave-option").click(function () {
                        var _option = $(this).attr("alt");
                        var _payChequeYear;
                        var _semester;
                        var _lotNo;
                        var _pvjvNo;
                        var _chequeNo;

                        $(this).blur();

                        if (_this.option.save.validate({
                                option: _option
                            }))
                        {
                            _payChequeYear  = $("#" + Util.tfs.ICL.savePeoplePayCheque.idContent + "-paychequeyear-hidden").val();
                            _semester       = $("#" + Util.tfs.ICL.savePeoplePayCheque.idContent + "-semester-hidden").val();
                            _lotNo          = $("#" + Util.tfs.ICL.savePeoplePayCheque.idContent + "-lotno-hidden").val();
                            _pvjvNo         = $("#" + Util.tfs.ICL.savePeoplePayCheque.idContent + "-pvjvno-hidden").val();
                            _chequeNo       = $("#" + Util.tfs.ICL.savePeoplePayCheque.idContent + "-chequeno-hidden").val();
                            
                            Util.loadForm({
                                name: Util.pageFinanceScholarshipTypeGroupICLSavePeoplePayChequeAddUpdate,
                                data: (_payChequeYear + "|" + _semester + "|" + _lotNo + "|" + _pvjvNo + "|" + _chequeNo),
                                dialog: true                                
                            }, function (_result, _e) {
                                if (_result.MainContent.length > 0)
                                    Util.tfs.ICL.savePeoplePayCheque.addupdate.init({
                                        option: _option
                                    });
                            });
                        }
                    });
                },

                clear: function () {
                    var _this = this;

                    $("#" + _this.idContent).html("");
                    Util.setBodyLayout();
                },
                
                option: {
                    save: {
                        validate: function (_param) {
                            _param.option = (_param.option == undefined ? "" : _param.option);

                            var _this = this;
                            var _error = false;
                            var _msgTH;
                            var _msgEN;
                            var _idContent = ("#" + Util.tfs.ICL.savePeoplePayCheque.list.idContent + " table" + " .select-child");

                            if (_error == false && _param.option == "all" && $(_idContent).length == 0) { _error = true; _msgTH = "ไม่พบข้อมูล"; _msgEN = "Data not found."; }
                            if (_error == false && _param.option == "selected" && $(_idContent + ":checked").length == 0) { _error = true; _msgTH = "กรุณาเลือกรายการ"; _msgEN = "Please select item."; }

                            if (_error == true)
                            {
                                Util.dialogMessage({
                                    type: "danger",
                                    msgTH: _msgTH,
                                    msgEN: _msgEN
                                }, function (_result) { });

                                return false;
                            }

                            return true;
                        }
                    }
                },
                /*
                form: {
                    reset: function (_param) {
                        _param.idParent = (_param.idParent == undefined ? "" : _param.idParent);
                        _param.idMain   = (_param.idMain == undefined ? "" : _param.idMain);
                
                        $(_param.idParent + " td").html("");
                        $(_param.idParent).addClass("hide");
                        $(_param.idMain).removeClass("hide");
                    },

                    init: function (_param) {
                        _param.idParent = (_param.idParent == undefined ? "" : _param.idParent);
                        _param.idMain   = (_param.idMain == undefined ? "" : _param.idMain);
           
                        Util.initClosePanel({
                            id: _param.idMain,
                            hide: true,
                            idHide: _param.idParent
                        }, function () { });
                    }
                }
                */
            },

            addupdate: {
                idContent: ("addupdate-" + SCHUtil.subjectFinanceScholarshipTypeGroupICLSavePeoplePayCheque.toLowerCase()),

                init: function (_param) {
                    _param.option = (_param.option == undefined ? "" : _param.option);

                    var _this = this;
                    var _data = {};
        
                    Util.textboxDisable("#" + _this.idContent + " input:text");
                    
                    $("#" + _this.idContent + " .button").click(function () {
                        var _idContent = $(this).attr("id");

                        $(this).blur();
           
                        if (_idContent == (_this.idContent + "-btnsave"))
                        {
                            _page = $(this).attr("alt");

                            Util.dialogConfirm({
                                msgTH: "ต้องการบันทึกข้อมูลนี้หรือไม่",
                                msgEN: "Do you want to save changes ?",
                                msgButtonCancelTH: "ยกเลิก",
                                msgButtonCancelEN: "Cancel",
                                msgButtonOKTH: "ตกลง",
                                msgButtonOKEN: "OK"
                            }, function (_result) {
                                if (_result == "Y")
                                {                                    
                                    if (_this.validate())
                                    {
                                        var _selectResult   = new Array();
                                        var _payChequeYear  = $("#" + Util.tfs.ICL.savePeoplePayCheque.idContent + "-paychequeyear-hidden").val();
                                        var _semester       = $("#" + Util.tfs.ICL.savePeoplePayCheque.idContent + "-semester-hidden").val();
                                        var _lotNo          = $("#" + Util.tfs.ICL.savePeoplePayCheque.idContent + "-lotno-hidden").val();
                                        var _pvjvNo         = $("#" + Util.tfs.ICL.savePeoplePayCheque.idContent + "-pvjvno-hidden").val();
                                        var _chequeNo       = $("#" + Util.tfs.ICL.savePeoplePayCheque.idContent + "-chequeno-hidden").val();

                                        $("#" + Util.tfs.ICL.savePeoplePayCheque.list.idContent + " table input[name=select-child]" + (_param.option == "selected" ? ":checked" : "")).each(function (_i) {
                                            _data               = {};
                                            _data               = $(this).data("value");
                                            _selectResult[_i]   = (_data.personId + ":" + 
                                                                   _data.scholarshipsYear + ":" + 
                                                                   _data.semester + ":" + 
                                                                   _data.scholarshipsId + ":" + 
                                                                   _payChequeYear + ":" +
                                                                   _semester + ":" +
                                                                   _lotNo + ":" +
                                                                   _pvjvNo + ":" +
                                                                   _chequeNo);
                                        });

                                        _data           = {};
                                        _data.selected  = _selectResult.join("|");

                                        _this.action({
                                            page: _page,
                                            data: _data,
                                        });
                                    }
                                }
                            });
                        }
                    });
                    
                    _this.reset({
                        option: _param.option
                    });
                },
                
                reset: function (_param) {
                    _param.option = (_param.option == undefined ? "" : _param.option);

                    var _this = this;
                    var _idContent = ("#" + Util.tfs.ICL.savePeoplePayCheque.list.idContent + " table" + " .select-child");
                    var _dataCount;
                    var _receiverNumberSave;
                    var _receiverNumber;
                    var _totalRecipient;
                    var _amountsave;
                    var _amount = 0;
                    var _totalAmount;

                    if (_param.option == "selected")    _dataCount = $(_idContent + ":checked").length;
                    if (_param.option == "all")         _dataCount = $(_idContent).length;
        
                    $("#" + _this.idContent + " .view .total").html(_dataCount);
                    $("#" + _this.idContent + " .view .totalcomplete, " +
                      "#" + _this.idContent + " .view .totalincomplete").html("");
                    $("#" + _this.idContent + " .view .totalunit, " +
                      "#" + _this.idContent + " .view .totalunit").hide();

                    _receiverNumberSave = Util.blockCharNotWanted(Util.delCommas("#" + _this.idContent + "-receivernumbersave"));
                    _receiverNumberSave = (_receiverNumberSave.length > 0 ? _receiverNumberSave : "0");
                    _receiverNumber     = _dataCount;
                    _amountsave         = Util.blockCharNotWanted(Util.delCommas("#" + _this.idContent + "-amountsave"));
                    _amountsave         = (_amountsave.length > 0 ? _amountsave : "0.00");
                    $("#" + Util.tfs.ICL.savePeoplePayCheque.list.idContent + " table input[name=select-child]" + (_param.option == "selected" ? ":checked" : "")).each(function (_i) {
                        _data           = {};
                        _data           = $(this).data("value");
                        _amount         = (_amount + parseFloat(_data.amount));
                    });
                    _totalRecipient     = (parseFloat(_receiverNumberSave) + _receiverNumber);
                    _totalAmount        = (parseFloat(_amountsave) + _amount);

                    $("#" + _this.idContent + "-receivernumber").val(_receiverNumber);
                    Util.addCommas((_this.idContent + "-receivernumber"), 0);
                    $("#" + _this.idContent + "-totalrecipient").val(_totalRecipient);
                    Util.addCommas((_this.idContent + "-totalrecipient"), 0);
                    $("#" + _this.idContent + "-amount").val(_amount);
                    Util.addCommas((_this.idContent + "-amount"), 2);
                    $("#" + _this.idContent + "-totalamount").val(_totalAmount);
                    Util.addCommas((_this.idContent + "-totalamount"), 2);
                },
                
                validate: function () {
                    var _this = this;
                    var _error = new Array();
                    var _i = 0;
                    var _amountDefault;
                    var _receiverNumberDefault;
                    var _totalRecipient;
                    var _totalAmount;
                    
                    _receiverNumberDefault  = Util.blockCharNotWanted(Util.delCommas("#" + Util.tfs.ICL.savePeoplePayCheque.idContent + "-receivernumber-hidden"));
                    _amountDefault          = Util.blockCharNotWanted(Util.delCommas("#" + Util.tfs.ICL.savePeoplePayCheque.idContent + "-amount-hidden"));
                    _totalRecipient         = Util.blockCharNotWanted(Util.delCommas("#" + _this.idContent + "-totalrecipient"));
                    _totalAmount            = Util.blockCharNotWanted(Util.delCommas("#" + _this.idContent + "-totalamount"));

                    if (parseFloat(_totalRecipient) > parseFloat(_receiverNumberDefault)) { _error[_i] = ("จำนวนผู้รับเงินที่เลือกมากกว่าจำนวนผู้รับเงินจากรายการจ่ายเช็ค;The number of recipient persons selected exceeds the number recipient by pay cheque.;"); _i++; }
                    if (parseFloat(_totalAmount) > parseFloat(_amountDefault)) { _error[_i] = ("จำนวนเงินของผู้รับเงินที่เลือกมากกว่าจำนวนเงินจากรายการจ่ายเช็ค;The amount of recipient selected exceeds the amount pay cheque.;"); _i++; }

                    Util.dialogListMessageError({
                        content: _error
                    });

                    return (_i > 0 ? false : true);
                },
                
                action: function (_param) {
                    _param.page = (_param.page == undefined ? "" : _param.page);
                    _param.data = (_param.data == undefined ? {} : _param.data);

                    var _this = this;
                    var _data = _param.data;
                    var _signinYN = "Y";
                    var _error;            
            
                    _data.signinYN = _signinYN;

                    Util.msgPreloading = "Saving...";
        
                    Util.actionTask({
                        action: "save",
                        page: _param.page,
                        data: _data
                    }, function (_result) {
                        _error = Util.getErrorMsg({
                                    signinYN: _signinYN,
                                    pageError: 0,
                                    cookieError: _result.CookieError,
                                    userError: _result.UserError,
                                    saveError: _result.SaveError
                                 });
            
                        $("#" + _this.idContent + "-saveresult").val(_error == false ? "Y" : "N");

                        if (_error == false)
                        {
                            $("#" + _this.idContent + " .view .totalcomplete").html(_result.Complete);
                            $("#" + _this.idContent + " .view .totalincomplete").html(_result.Incomplete);
                            $("#" + _this.idContent + " .view .totalunit, " +
                              "#" + _this.idContent + " .view .totalunit").show();

                            Util.dialogMessage({
                                type: "info",
                                msgTH: "บันทึกข้อมูลเรียบร้อย",
                                msgEN: "Save complete."
                            }, function (_result) {
                                $(".dialogform .btnclose").click();
                            });
                        }
                    });
                }
            }
        },

        studentCV: {
            idContent: ("main-" + SCHUtil.subjectFinanceScholarshipTypeGroupICLStudentCV.toLowerCase()),
            
            form: function (_param) {
                _param.data     = (_param.data == undefined || _param.data == "" ? {} : _param.data);
                _param.idParent = (_param.idParent == undefined ? "" : _param.idParent);
                _param.idMain   = (_param.idMain == undefined ? "" : _param.idMain);

                var _this = this;
                var _id = (_param.data.personId + _param.data.scholarshipsYear + _param.data.semester + _param.data.scholarshipsId);
                var _idParent = (_param.idParent + "-studentcv-" + _id);
                var _idMain = (_param.idMain + "-id-" + _id);
                
                Util.tfs.ICL.savePeopleApproved.list.form.reset({
                    idParent: ("#" + _param.idParent + " table tr.ui." + Util.subjectStudentCV.toLowerCase()),
                    idMain: ("#" + _idParent)
                });
            
                Util.loadForm({
                    name: Util.pageFinanceScholarshipTypeGroupICLStudentCVMain,
                    data: (_param.data.personId + "|" + _param.data.scholarshipsYear + "|" + _param.data.semester + "|" + _param.data.scholarshipsId),
                    showPreloadingInline: true,
                    idPreloadingInline: _idMain,
                    id: ("#" + _idMain)
                }, function (_result) {
                    if (_result.MainContent.length > 0)
                    {
                        Util.tfs.ICL.savePeopleApproved.list.form.init({
                            idParent: ("#" + _idParent),
                            idMain: ("#" + _idMain)
                        });
                        
                        _this.reset({
                            id: ("#" + _idMain)
                        });
                    }
                    else
                        $("#" + _idParent).addClass("hide").hide();
                });
            },
            
            reset: function (_param) {
                _param.id = (_param.id == undefined ? "" : _param.id);

                var _this = this;

                Util.getStudentPicture({
                    id: _param.id,
                    src: $(_param.id + " .studentpicture-hidden").val()
                });
            }
        }
    }
}