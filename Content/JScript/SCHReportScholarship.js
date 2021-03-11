var SCHReportScholarship = {
    main: {
        idContent: ("main-" + SCHUtil.subjectReportScholarship.toLowerCase()),

        init: function () {
            var _this = this;

            $("#" + _this.idContent + " .tabular.menu .item").click(function () {
                var _tab = $(this).data("tab");

                if (_tab == Util.subjectReportListOfPeopleApprovedFinanceFromICL.toLowerCase())
                {
                    Util.loadForm({
                        name: Util.pageReportListOfPeopleApprovedFinanceFromICLMain,
                        id: ("#tab-" + Util.subjectReportScholarship.toLowerCase())
                    }, function (_result) {
                        if (_result.MainContent.length > 0)
                        {                            
                            $("#" + _this.idContent + " .tabular.menu").hide();
                            $("#tab-" + Util.subjectReportScholarship.toLowerCase()).show();
                            $("#main-quicksearch").removeClass("hide");
                            $("#main-keyword").val("");
                            Util.setBodyLayout();
                            Util.gotoTopElement();

                            Util.tps.listOfPeopleApprovedFinanceFromICL.init();
                        }
                    });
                }
            });
        }
    },

    listOfPeopleApprovedFinanceFromICL: {
        idContent: ("main-" + SCHUtil.subjectReportListOfPeopleApprovedFinanceFromICL.toLowerCase()),

        init: function () {
            var _this = this;
            
            Util.initClosePanel({
                id: ("#tab-" + Util.subjectReportScholarship.toLowerCase()),
                hide: true,
                idHide: ("#tab-" + Util.subjectReportScholarship.toLowerCase()),
                show: true,
                idShow: ("#" + Util.tps.main.idContent + " .tabular.menu")
            }, function () {
                $("#main-quicksearch").addClass("hide");
            });

            _this.search.init();
        },

        search: {
            idContent: ("search-" + SCHUtil.subjectReportListOfPeopleApprovedFinanceFromICL.toLowerCase()),

            init: function () {
                var _this = this;

                Util.initShrinkPanel({
                    id: ("#" + _this.idContent)
                });                    
                Util.initDropdown({
                    id: ("#" + _this.idContent)
                }, function (_result) {
                    Util.tps.listOfPeopleApprovedFinanceFromICL.list.clear();
                });
                                    
                $("#" + _this.idContent + " .button").click(function () {
                    var _idContent = $(this).attr("id");

                    $(this).blur();

                    if (_idContent == (_this.idContent + "-btnsearch"))
                    {
                        if (_this.validate())
                            _this.action(function () {
                                Util.gotoElement({
                                    anchorName: ("#" + Util.tps.listOfPeopleApprovedFinanceFromICL.list.idContent),
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
                _data.recipientStatus       = "Y";

                return _data;
            },
                
            action: function (_callBackFunc) {
                var _this = this;
                var _data = {};
       
                Util.tps.listOfPeopleApprovedFinanceFromICL.list.clear();

                _data = _this.value();

                Util.msgPreloading = "Searching...";

                Util.actionTask({
                    action: "search",
                    page: Util.pageReportListOfPeopleApprovedFinanceFromICLMain,
                    data: _data
                }, function (_result) {
                    $("#" + Util.tps.listOfPeopleApprovedFinanceFromICL.list.idContent).html(_result.List);
                    $("#" + Util.tps.listOfPeopleApprovedFinanceFromICL.list.idContent + " .recordcountprimary-search").html(_result.RecordCountPrimary);
                    $("#" + Util.tps.listOfPeopleApprovedFinanceFromICL.list.idContent + " .sum-search").html(_result.Sum);
                    $("#" + Util.tps.listOfPeopleApprovedFinanceFromICL.list.idContent + " .table-navpage").html(_result.NavPage);

                    Util.setBodyLayout();
                    Util.setLanguageOnForm({
                        id: ("#" + Util.tps.listOfPeopleApprovedFinanceFromICL.list.idContent)
                    });

                    Util.tps.listOfPeopleApprovedFinanceFromICL.list.init();
                    _callBackFunc();
                });
            }
        },

        list: {
            idContent: ("list-" + SCHUtil.subjectReportListOfPeopleApprovedFinanceFromICL.toLowerCase()),
            
            init: function () {
                var _this = this;
                var _i;
                
                for (_i = 0; _i < $("#" + _this.idContent + " table thead th").length; _i++)
                {
                    Util.initTooltip({
                        id: ("#" + _this.idContent + " table td.col" + (_i + 1))
                    });
                }
                
                $("#" + _this.idContent + " .button").click(function () {
                    var _option = "all";
                    var _data = {};
                    var _idContent;
                        
                    $(this).blur();

                    if ($(this).hasClass("btnstudentcv"))
                    {
                        _data = $(this).data("value");

                        Util.tps.studentCV.form({
                            data: _data,
                            idParent: _this.idContent,
                            idMain: Util.tps.listOfPeopleApprovedFinanceFromICL.idContent
                        });
                    }

                    if ($(this).hasClass("btnexport-option"))
                    {
                        if (_this.option.export.validate({
                                option: _option
                            }))
                        {
                            Util.loadForm({
                                name: Util.pageReportListOfPeopleApprovedFinanceFromICLExport,
                                dialog: true,
                            }, function (_result, _e) {
                                if (_result.MainContent.length > 0)
                                    Util.tps.listOfPeopleApprovedFinanceFromICL.export.init({
                                        option: _option,
                                    });
                            });
                        }
                    }
                });  
            },
            
            clear: function () {
                var _this = this;

                $("#" + _this.idContent).html("");
                Util.setBodyLayout();
            },

            option: {
                export: {
                    validate: function (_param) {
                        _param.option = (_param.option == undefined ? "" : _param.option);

                        var _this = this;
                        var _error = false;
                        var _msgTH;
                        var _msgEN;
                        var _idContent = ("#" + Util.tps.listOfPeopleApprovedFinanceFromICL.idContent + " table tbody tr");

                        if (_error == false && _param.option == "all" && $(_idContent + ":visible").length == 0) { _error = true; _msgTH = "ไม่พบข้อมูล"; _msgEN = "Data not found."; }

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

        export: {
            idContent: ("export-" + SCHUtil.subjectReportListOfPeopleApprovedFinanceFromICL.toLowerCase()),

            init: function (_param) {
                _param.option = (_param.option == undefined ? "" : _param.option);

                var _this = this;
                var _data = {};
                var _paramSearch = {};
                var _selected;                
       
                $("#" + _this.idContent + " .button").click(function () {
                    var _idContent = $(this).attr("id");

                    $(this).blur();
            
                    if (_idContent == (_this.idContent + "-btnexport"))
                    {
                        var _page = $(this).attr("alt");

                        Util.dialogConfirm({
                            msgTH: "ต้องการส่งออกข้อมูลนี้หรือไม่",
                            msgEN: "Do you want to export ?",
                            msgButtonCancelTH: "ยกเลิก",
                            msgButtonCancelEN: "Cancel",
                            msgButtonOKTH: "ตกลง",
                            msgButtonOKEN: "OK"
                        }, function (_result) {
                            if (_result == "Y")
                            {
                                if (_this.validate())
                                {
                                    if (_param.option == "all")
                                    {
                                        _selected       = "";
                                        _paramSearch    = Util.tps.listOfPeopleApprovedFinanceFromICL.search.value();
                                    }

                                    _data           = _paramSearch;
                                    _data.selected  = _selected;
                                    _data.option    = _param.option;                                    

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
                    option: _param.option,
                });
            },

            reset: function (_param) {
                _param.option = (_param.option == undefined ? "" : _param.option);

                var _this = this;
                var _recordCount = ($("#" + Util.tps.listOfPeopleApprovedFinanceFromICL.list.idContent + " .table-title .recordcountprimary-search").length > 0 ? $("#" + Util.tps.listOfPeopleApprovedFinanceFromICL.list.idContent + " .table-title .recordcountprimary-search:eq(0)").html() : "");
                var _dataCount;

                if (_param.option == "all") _dataCount = (_recordCount.length > 0 && _recordCount != "0" ? _recordCount : "0");
        
                $("#" + _this.idContent + " .view .total").html(_dataCount);
                $("#" + _this.idContent + " .view .totalcomplete, " +
                  "#" + _this.idContent + " .view .totalincomplete").html("");
                $("#" + _this.idContent + " .view .totalunit, " +
                  "#" + _this.idContent + " .view .totalunit").hide();
            },

            validate: function (_param) {
                var _this = this;
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

                Util.msgPreloading = "Exporting...";
            
                Util.actionTask({
                    action: "export",
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

                    $("#" + _this.idContent + "-exportresult").val(_error == false ? "Y" : "N");

                    if (_error == false)
                    {
                        $("#" + _this.idContent + " .view .totalcomplete").html(_result.Complete);
                        $("#" + _this.idContent + " .view .totalincomplete").html(_result.Incomplete);
                        $("#" + _this.idContent + " .view .totalunit, " +
                            "#" + _this.idContent + " .view .totalunit").show();

                        Util.dialogMessage({
                            type: "info",
                            msgTH: "ส่งออกข้อมูลเรียบร้อย",
                            msgEN: "Export complete."
                        }, function () {
                            $(".dialogform .btnclose").click();
                        });

                        Util.viewFile({
                            url: ("../Module/SCHDownloadFile.aspx?" +
                                  "action=" + Util.subjectReportListOfPeopleApprovedFinanceFromICL + "&" +
                                  "p=" + _result.DownloadFolder + "&" +
                                  "f=" + _result.DownloadFile)
                        });
                    }
                });
            }
        }
    },

    studentCV: {
        idContent: ("main-" + SCHUtil.subjectReportScholarshipStudentCV.toLowerCase()),
            
        form: function (_param) {
            _param.data     = (_param.data == undefined || _param.data == "" ? {} : _param.data);
            _param.idParent = (_param.idParent == undefined ? "" : _param.idParent);
            _param.idMain   = (_param.idMain == undefined ? "" : _param.idMain);

            var _this = this;
            var _id = (_param.data.personId + _param.data.scholarshipsYear + _param.data.semester + _param.data.scholarshipsId);
            var _idParent = (_param.idParent + "-studentcv-" + _id);
            var _idMain = (_param.idMain + "-id-" + _id);

            Util.tps.listOfPeopleApprovedFinanceFromICL.list.form.reset({
                idParent: ("#" + _param.idParent + " table tr.ui." + Util.subjectStudentCV.toLowerCase()),
                idMain: ("#" + _idParent)
            });
            
            Util.loadForm({
                name: Util.pageReportScholarshipStudentCVMain,
                data: (_param.data.personId + "|" + _param.data.scholarshipsYear + "|" + _param.data.semester + "|" + _param.data.scholarshipsId),
                showPreloadingInline: true,
                idPreloadingInline: _idMain,
                id: ("#" + _idMain)
            }, function (_result) {
                if (_result.MainContent.length > 0)
                {
                    Util.tps.listOfPeopleApprovedFinanceFromICL.list.form.init({
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