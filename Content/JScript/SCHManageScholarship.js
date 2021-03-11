var SCHManageScholarship = {
    main: {
        idContent: ("main-" + SCHUtil.subjectManageScholarship.toLowerCase()),

        init: function () {
            var _this = this;

            Util.tms.search.init();
            Util.tms.studentCancel.main.init();
        }
    },

    search: {
        idContent: ("search-" + SCHUtil.subjectManageScholarship.toLowerCase()),

        init: function () {
            var _this = this;

            Util.initShrinkPanel({
                id: ("#" + _this.idContent)
            });
            Util.initDropdown({
                id: ("#" + _this.idContent)
            }, function (_result) {
                Util.tms.list.clear();
            });
        
            $("#" + _this.idContent + " .button").click(function () {
                var _idContent = $(this).attr("id");

                $(this).blur();

                if (_idContent == (_this.idContent + "-btnsearch"))
                {
                    if (_this.validate())
                    {                    
                        Util.tms.list.clear();
                        _this.action({
                            page: Util.pageManageScholarshipMain,
                            data: _this.value(),
                            id: ("#" + Util.tms.list.idContent)
                        }, function () {
                            Util.tms.list.init()
                            $("#" + Util.tms.studentCancel.main.idContent).show();
                            Util.tms.studentCancel.list.clear();

                            Util.gotoElement({
                                anchorName: ("#" + Util.tms.list.idContent),
                                top: ($("#followingmenu").outerHeight())
                            });
                        });
                    }
                }
            });
        
            _this.reset();
        },

        reset: function () {
            var _this = this;

            $("#" + _this.idContent + "-faculty").dropdown("set selected", $("#main-userfaculty-hidden").val());
            $("#" + _this.idContent + "-yearentry").dropdown("set selected", $("#main-currentyear-hidden").val());
        },

        validate: function () {
            var _this = this;
            var _error = new Array();
            var _scholarshipsId = Util.getDropdrownValue({ id: ("#" + _this.idContent + "-scholarships") });
            var _i = 0;

            if (_scholarshipsId == "0") { _error[_i] = ("กรุณาเลือกทุน;Please select scholarship.;"); _i++; }

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
            var _scholarshipsId             = Util.getSelectionIsSelect({
                                                id: ("#" + _this.idContent + "-scholarships"),
                                                type: "select",
                                                valueTrue: Util.getDropdrownValue({
                                                                id: ("#" + _this.idContent + "-scholarships")
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
            _data.scholarshipsYear      = (_scholarshipsYearSemester.length > 0 ? _scholarshipsYearSemester.split(":")[0] : "");
            _data.semester              = (_scholarshipsYearSemester.length > 0 ? _scholarshipsYearSemester.split(":")[1] : "");
            _data.scholarshipsId        = (_scholarshipsId.length > 0 ? _scholarshipsId.split(":")[0] : "");
            _data.scholarshipsTypeGroup = (_scholarshipsId.length > 0 ? _scholarshipsId.split(":")[1] : "");

            return _data;
        },

        action: function (_param, _callBackFunc) {
            _param.page = (_param.page == undefined ? "" : _param.page);
            _param.data = (_param.data == undefined ? {} : _param.data);
            _param.id   = (_param.id == undefined ? "" : _param.id);

            var _this = this;
            var _data = _param.data;        

            Util.msgPreloading = "Searching...";

            Util.actionTask({
                action: "search",
                page: _param.page,
                data: _data
            }, function (_result) {
                $(_param.id).html(_result.List);
                $(_param.id + " .recordcountprimary-search").html(_result.RecordCountPrimary);
                $(_param.id + " .table-navpage").html(_result.NavPage);

                Util.setBodyLayout();
                Util.setLanguageOnForm({
                    id: _param.id
                });            

                _callBackFunc();
            });
        }
    },

    list: {
        idContent: ("list-" + SCHUtil.subjectManageScholarship.toLowerCase()),

        init: function () {
            var _this = this;
            var _i;
        
            Util.initCheck({
                id: ("#" + _this.idContent + " .checkbox")
            });
            Util.initCheck({
                id: ("#" + _this.idContent + " .radio")
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

            $("#" + _this.idContent + " .textbox-numeric").keyup(function () {
                return Util.extractNumber(this, 2, false);
            });

            $("#" + _this.idContent + " .textbox-numeric").keypress(function (_e) {
                return Util.blockNonNumbers(this, _e, true, false);
            });

            $("#" + _this.idContent + " .textbox-numeric").focusout(function () {
                Util.addCommas($(this).attr("id"), 2);
                ($(this).val($(this).val().length > 12 ? $(this).val().substring($(this).val().length, $(this).val().length - 12) : $(this).val()));
                $(this).val(Util.delCommas("#" + $(this).attr("id")));
                Util.addCommas($(this).attr("id"), 2);
                $(this).val(Util.blockCharNotWanted($(this).val()));
            });
        
            $("#" + _this.idContent + " .button").click(function () {
                var _option = "selected";
                var _scholarshipsTypeGroup = Util.tms.search.value().scholarshipsTypeGroup
                var _data = {};
                var _idContent;            

                $(this).blur();

                if ($(this).hasClass("btnstudentcv"))
                {
                    _data = $(this).data("value");

                    if (_scholarshipsTypeGroup == "")
                    {
                        Util.tms.studentCV.form({
                            data: _data,
                            idParent: _this.idContent,
                            idMain: Util.tms.studentCV.idContent
                        });
                    }

                    if (_scholarshipsTypeGroup == Util.subjectICL)
                    {
                        if (Util.tms.ICL.validate({
                                data: _data
                            }))
                        {
                            Util.loadForm({
                                name: Util.pageManageScholarshipTypeGroupICLAddUpdate,
                                data: (_data.personId + "|" + _data.scholarshipsYear + "|" + _data.semester + "|" + _data.scholarshipsId),
                                dialog: true,
                            }, function (_result, _e) {
                                if (_result.MainContent.length > 0)
                                    Util.tms.ICL.addupdate.init();
                            });
                        }
                        else
                            {
                                Util.tms.studentCV.form({
                                    data: _data,
                                    idParent: _this.idContent,
                                    idMain: Util.tms.studentCV.idContent
                                });
                            }
                    }
                }

                if ($(this).hasClass("btnsave-option"))
                {
                    if (_this.option.save.validate({
                            action: "save",
                            option: _option
                        }))
                    {
                        Util.loadForm({
                            name: Util.pageManageScholarshipAddUpdate,
                            dialog: true,
                        }, function (_result, _e) {
                            if (_result.MainContent.length > 0)
                                Util.tms.addupdate.init({
                                    page: Util.pageManageScholarshipAddUpdate,
                                    option: _option,
                                    scholarshipsTypeGroup: _scholarshipsTypeGroup
                                });
                        });
                    }
                }

                if ($(this).hasClass("btncancel-option"))
                {
                    if (_this.option.save.validate({
                            action: "cancel",
                            option: _option
                        }))
                    {
                        Util.loadForm({
                            name: Util.pageManageScholarshipStudentCancelAddUpdate,
                            dialog: true,
                        }, function (_result, _e) {
                            if (_result.MainContent.length > 0)
                                Util.tms.addupdate.init({
                                    page: Util.pageManageScholarshipStudentCancelAddUpdate,
                                    option: _option,
                                    scholarshipsTypeGroup: _scholarshipsTypeGroup
                                });
                        });
                    }
                }
            });
        },

        clear: function () {
            var _this = this;
        
            $("#" + _this.idContent).html("");
            Util.tms.studentCancel.list.clear();
            $("#" + Util.tms.studentCancel.main.idContent).hide();
            Util.setBodyLayout();
        },

        option: {
            save: {
                validate: function (_param) {
                    _param.action   = (_param.action == undefined ? "" : _param.action);
                    _param.option   = (_param.option == undefined ? "" : _param.option);

                    var _this = this;
                    var _error = false;
                    var _msgTH;
                    var _msgEN;
                    var _objCheck = $("#" + Util.tms.list.idContent + " table" + " .select-child:checked");
                    var _data;
                    var _id;        
                    var _amount;
                    var _regisCase;

                    if (_error == false && _param.option == "selected" && _objCheck.length == 0) { _error = true; _msgTH = "กรุณาเลือกรายการ"; _msgEN = "Please Select Item."; }
                    if (_error == false && _param.action == "save" && _param.option == "selected")
                    {           
                        $("#" + Util.tms.list.idContent + " table input[name=select-child]:checked").each(function (_i) {
                            _data       = {};
                            _data       = $(this).data("value"),
                            _id         = (_data.personId + _data.scholarshipsYear + _data.semester + _data.scholarshipsId);                
                            _amount     = ("#" + Util.tms.list.idContent + "-amount-" + _id);
                            _regisCase  = ("input[name=" + Util.tms.list.idContent + "-regiscase-" + _id + "]");
                            
                            if (_error == false && _data.scholarshipsId.length == 0) { _error = true; _msgTH = ("กรุณาเลือกทุนของนักศึกษารหัส " + _data.studentId); _msgEN = ("Please select scholarship in student id " + _data.studentId + "."); }
                            if (_error == false && _data.scholarshipsTypeGroup == "" && $(_amount).val().length == 0) { _error = true; _msgTH = ("กรุณาระบุจำนวนเงินทุนของนักศึกษารหัส " + _data.studentId); _msgEN = ("Please enter amount in student id " + _data.studentId + "."); }
                            if (_error == false && _data.scholarshipsTypeGroup == "" && $(_regisCase).is(":checked") == false) { _error = true; _msgTH = ("กรุณาเลือกประเภทของการจ่ายเงินทุนของนักศึกษารหัส " + _data.studentId); _msgEN = ("Please select pay type in student id " + _data.studentId + "."); }

                            if (_error == true)
                               return false;
                        });
                    }

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

                var _this = this;
            
                Util.initClosePanel({
                    id: _param.idMain,
                    hide: true,
                    idHide: _param.idParent
                }, function () { });
            },
        }
    },

    studentCV: {
        idContent: ("main-" + SCHUtil.subjectManageScholarshipStudentCV.toLowerCase()),
        
        form: function (_param) {
            _param.data     = (_param.data == undefined || _param.data == "" ? {} : _param.data);
            _param.idParent = (_param.idParent == undefined ? "" : _param.idParent);
            _param.idMain   = (_param.idMain == undefined ? "" : _param.idMain);

            var _this = this;
            var _id = (_param.data.personId + _param.data.scholarshipsYear + _param.data.semester + _param.data.scholarshipsId);
            var _idParent = (_param.idParent + "-studentcv-" + _id);
            var _idMain = (_param.idMain + "-id-" + _id)     
            
            Util.tms.list.form.reset({
                idParent: ("#" + _param.idParent + " table tr.ui." + Util.subjectStudentCV.toLowerCase()),
                idMain: ("#" + _idParent)
            });
            
            Util.loadForm({
                name: Util.pageManageScholarshipStudentCVMain,
                data: (_param.data.personId + "|" + _param.data.scholarshipsYear + "|" + _param.data.semester + "|" + _param.data.scholarshipsId),
                showPreloadingInline: true,
                idPreloadingInline: _idMain,
                id: ("#" + _idMain)
            }, function (_result) {
                if (_result.MainContent.length > 0)
                {
                    Util.tms.list.form.init({
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
    },

    studentCancel: {
        main: {
            idContent: ("main-" + SCHUtil.subjectManageScholarshipStudentCancel.toLowerCase()),

            init: function () {
                var _this = this;

                Util.initShrinkPanel({
                    id: ("#" + _this.idContent)
                });
                $("#" + _this.idContent).hide();

                $("#" + _this.idContent + " .btnrefresh").click(function () {
                    Util.tms.studentCancel.search.action(function () {
                        $("#" + _this.idContent + " .btnshrink").click();

                        Util.tms.studentCancel.list.init();

                        Util.gotoElement({
                            anchorName: ("#" + _this.idContent),
                            top: ($("#followingmenu").outerHeight())
                        });
                    });
                });
            }
        },

        search: {
            value: function () {
                var _this = this;
                var _data = {};

                _data               = Util.tms.search.value();
                _data.cancelStatus  = "Y";

                return _data;
            },

            action: function (_callBackFunc) {
                var _this = this;
                
                Util.tms.studentCancel.list.clear();
                Util.tms.search.action({
                    page: Util.pageManageScholarshipStudentCancelMain,
                    data: _this.value(),
                    id: ("#" + Util.tms.studentCancel.list.idContent)
                }, function (_result) {
                    _callBackFunc();
                });
            }
        },

        list: {
            idContent: ("list-" + SCHUtil.subjectManageScholarshipStudentCancel.toLowerCase()),

            init: function () {
                var _this = this;
                var _i;
                var _j = 0;

                for (_i = 0; _i < $("#" + _this.idContent + " table thead th").length; _i++)
                {
                    if ($("#" + _this.idContent + " table td.col" + (_i + 1)).length == 0)
                        _j++;

                    Util.initTooltip({
                        id: ("#" + _this.idContent + " table td.col" + (_i + 1 + _j))
                    });
                }
                Util.initTable({
                    id: ("#" + _this.idContent + " table")
                })

                $("#" + _this.idContent + " .button").click(function () {
                    var _data = {};
                    var _idContent;

                    $(this).blur();
            
                    if ($(this).hasClass("btnstudentcv"))
                    {                
                        Util.tms.studentCV.form({
                            data: $(this).data("value"),
                            idParent: _this.idContent,
                            idMain: Util.tms.studentCancel.studentCV.idContent
                        });
                    }
                });
            },

            clear: function () {
                var _this = this;

                $("#" + Util.tms.studentCancel.main.idContent + " .panel-bodys").show();
                $("#" + Util.tms.studentCancel.main.idContent + " .btnshrink").click();
                $("#" + _this.idContent).html("");
                Util.setBodyLayout();
            },
        },

        studentCV: {
            idContent: ("main-" + SCHUtil.subjectManageScholarshipStudentCancelStudentCV.toLowerCase()),
        }
    },

    addupdate: {
        idContent: ("addupdate-" + SCHUtil.subjectManageScholarship.toLowerCase()),

        init: function (_param) {
            _param.page                     = (_param.page == undefined ? "" : _param.page);
            _param.option                   = (_param.option == undefined ? "" : _param.option);
            _param.scholarshipsTypeGroup    = (_param.scholarshipsTypeGroup == undefined ? "" : _param.scholarshipsTypeGroup);

            var _this = this;
            var _data = {};
            var _selected;
            var _paramSearch;
       
            Util.initCalendar({
                id: ("#" + _this.idContent + " .ui.calendar")
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
                            if (_this.validate({
                                page: _param.page,
                                scholarshipsTypeGroup: _param.scholarshipsTypeGroup
                            }))
                            {                            
                                var _data;
                                var _id;
                                var _amount;
                                var _regisCase;
                                var _contractDate;
                                var _cancelStatus;
                                var _reason;
                                var _selectResult = new Array();

                                if (_param.option == "selected")
                                {
                                    $("#" + Util.tms.list.idContent + " table input[name=select-child]:checked").each(function (_i) {
                                        _data           = $(this).data("value"),
                                        _id             = (_data.personId + _data.scholarshipsYear + _data.semester + _data.scholarshipsId);                                    
                                        _amount         = ("#" + Util.tms.list.idContent + "-amount-" + _id);
                                        _regisCase      = ("input[name=" + Util.tms.list.idContent + "-regiscase-" + _id + "]");
                                        _contractDate   = ("#" + _this.idContent + "-contractdate");
                                        _reason         = ("#" + _this.idContent + "-reason");

                                        if (_page == Util.pageManageScholarshipAddUpdate)
                                        {                                                                                                                                                
                                            _amount         = (_param.scholarshipsTypeGroup == "" ? Util.delCommas(_amount) : "");
                                            _regisCase      = (_param.scholarshipsTypeGroup == "" ? $(_regisCase + ":checked").val() : "");
                                            _contractDate   = (_param.scholarshipsTypeGroup == Util.subjectICL ? Util.getCalendarValue({ id: _contractDate }) : "")
                                            _cancelStatus   = "";
                                            _reason         = "";
                                        }
                                        if (_page == Util.pageManageScholarshipStudentCancelAddUpdate)
                                        {                                        
                                            _amount         = "";
                                            _regisCase      = "";
                                            _contractDate   = "";
                                            _cancelStatus   = "Y";
                                            _reason         = $(_reason).val();
                                        }

                                        _selectResult[_i] = (this.value + ":" + _amount + ":" + _regisCase);
                                    });

                                    _selected       = _selectResult.join("|");
                                    _paramSearch    = "";
                                }
                                _data               = {};
                                _data.option        = _param.option;
                                _data.selected      = _selected;
                                _data.contractDate  = _contractDate;
                                _data.cancelStatus  = _cancelStatus;
                                _data.reason        = _reason;           
                                _data.paramSearch   = _paramSearch;

                                _this.action({
                                    page: _page,
                                    data: _data,
                                    scholarshipsTypeGroup: _param.scholarshipsTypeGroup
                                });
                            }
                        }
                    });
                }
            });

            _this.reset({
                page: _param.page,
                option: _param.option,
                scholarshipsTypeGroup: _param.scholarshipsTypeGroup
            });
        },

        reset: function (_param) {
            _param.page                     = (_param.page == undefined ? "" : _param.page);
            _param.option                   = (_param.option == undefined ? "" : _param.option);
            _param.scholarshipsTypeGroup    = (_param.scholarshipsTypeGroup == undefined ? "" : _param.scholarshipsTypeGroup);

            var _this = this;
            var _recordCount = ($("#" + Util.tms.list.idContent + " .table-title .recordcountprimary-search").length > 0 ? $("#" + Util.tms.list.idContent + " .table-title .recordcountprimary-search:eq(0)").html() : "");
            var _objCheck = $("#" + Util.tms.list.idContent + " table" + " .select-child:checked");
            var _dataCount;

            if (_param.option == "selected")    _dataCount = _objCheck.length;
            if (_param.option == "all")         _dataCount = (_recordCount.length > 0 && _recordCount != "0" ? _recordCount : "0");
        
            $("#" + _this.idContent + " .view .total").html(_dataCount);
            $("#" + _this.idContent + " .view .totalcomplete, " +
              "#" + _this.idContent + " .view .totalincomplete").html("");
            $("#" + _this.idContent + " .view .totalunit, " +
              "#" + _this.idContent + " .view .totalunit").hide();

            if (_param.scholarshipsTypeGroup == Util.subjectICL) $("#" + _this.idContent + " .form .scholarshipstypegroupicl").removeClass("hide");
        },

        validate: function (_param) {
            _param.page                     = (_param.page == undefined ? "" : _param.page);
            _param.scholarshipsTypeGroup    = (_param.scholarshipsTypeGroup == undefined ? "" : _param.scholarshipsTypeGroup);

            var _this = this;
            var _error = new Array();
            var _contractDate = Util.getCalendarValue({ id: ("#" + _this.idContent + "-contractdate") });;
            var _reason = $("#" + _this.idContent + "-reason").val();
            var _i = 0;

            if (_param.page == Util.pageManageScholarshipAddUpdate)
            {
                if (_param.scholarshipsTypeGroup == Util.subjectICL && _contractDate.length == 0) { _error[_i] = ("กรุณาระบุวันทำสัญญา;Please enter contract date.;"); _i++; }
            }

            if (_param.page == Util.pageManageScholarshipStudentCancelAddUpdate)
            {
                if (_reason.length == 0) { _error[_i] = ("กรุณาระบุเหตุผลในการยกเลิกทุน;Please enter reason for cancel.;"); _i++; }
            }

            Util.dialogListMessageError({
                content: _error
            });

            return (_i > 0 ? false : true);
        },

        action: function (_param) {
            _param.page                     = (_param.page == undefined ? "" : _param.page);
            _param.data                     = (_param.data == undefined ? {} : _param.data);
            _param.scholarshipsTypeGroup    = (_param.scholarshipsTypeGroup == undefined ? "" : _param.scholarshipsTypeGroup);

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

                    Util.uncheckboxRoot("#" + Util.tms.list.idContent + " table .select-root");
                    $("#" + Util.tms.list.idContent + " table .select-child").iCheck("uncheck");

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
    },

    ICL: {
        list: {
            idContent: ("list-" + SCHUtil.subjectManageScholarshipTypeGroupICL.toLowerCase())
        },

        validate: function (_param) {
            _param.data = (_param.data == undefined || _param.data == "" ? {} : _param.data);

            var _error = false;
            var _id = (_param.data.personId + _param.data.scholarshipsYear + _param.data.semester + _param.data.scholarshipsId);            

            if (_error == false && _param.data.statusGroup != "00") _error = true;
            if (_error == false && _param.data.contractDate.length == 0) _error = true;
            if (_error == false && _param.data.contractDate.length > 0 && _param.data.approveDate.length > 0) _error = true;

            if (_error == true)
                return false;

            return true;
        },

        addupdate: {
            idContent: ("addupdate-" + SCHUtil.subjectManageScholarshipTypeGroupICL.toLowerCase()),

            init: function () {
                var _this = this;

                $("#" + _this.idContent + " .textbox-numeric").keyup(function () {
                    return Util.extractNumber(this, 2, false);
                });

                $("#" + _this.idContent + " .textbox-numeric").keypress(function (_e) {
                    return Util.blockNonNumbers(this, _e, true, false);
                });

                $("#" + _this.idContent + "-invoiceamount, #" + _this.idContent + "-amount").keyup(function () {
                    _this.calculate();
                });

                $("#" + _this.idContent + " .textbox-numeric").focusout(function () {
                    Util.addCommas($(this).attr("id"), 2);
                    ($(this).val($(this).val().length > 12 ? $(this).val().substring($(this).val().length, $(this).val().length - 12) : $(this).val()));
                    $(this).val(Util.delCommas("#" + $(this).attr("id")));
                    Util.addCommas($(this).attr("id"), 2);
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
                                _this.validate(function (_result) {
                                    if (_result == true)
                                        _this.action({
                                            page: _page,
                                            data: _this.value()
                                        });
                                });
                            }
                        });
                    }
                });

                _this.reset();
            },

            reset: function () {
                var _this = this;
                var _scholarshipsyearsemester = ("#" + _this.idContent + "-scholarshipsyearsemester");
                var _invoiceNo = ("#" + _this.idContent + "-invoiceno");
                var _totalCredit = ("#" + _this.idContent + "-totalcredit")
                var _ratePerYear = ("#" + _this.idContent + "-rateperyear");
                var _ratePerYearRemain = ("#" + _this.idContent + "-rateperyearremain");
                var _invoiceAmount = ("#" + _this.idContent + "-invoiceamount");
                var _tuition = ("#" + _this.idContent + "-amount");
                var _stdPayAmount = ("#" + _this.idContent + "-stdpayamount");

                Util.tms.studentCV.reset({
                    id: ("#" + _this.idContent)
                });
                Util.textboxDisable(_scholarshipsyearsemester);
                Util.textboxDisable(_invoiceNo);
                Util.textboxDisable(_totalCredit);
                Util.textboxDisable(_ratePerYear);
                Util.textboxDisable(_ratePerYearRemain);
                Util.textboxDisable(_stdPayAmount);

                $(_stdPayAmount).val($(_invoiceAmount).val().length > 0 && $(_tuition).val().length > 0 && $(_stdPayAmount).val().length == 0 ? "0.00" : $(_stdPayAmount).val());
                _this.calculate();
            },

            calculate: function () {
                var _this = this;
                var _ratePerYearRemain  = Util.delCommas("#" + _this.idContent + "-rateperyearremain-hidden");
                var _invoiceAmount      = Util.delCommas("#" + _this.idContent + "-invoiceamount");
                var _amount             = Util.delCommas("#" + _this.idContent + "-amount-hidden");
                var _tuition            = Util.delCommas("#" + _this.idContent + "-amount");
                var _stdPayAmount
                        
                _ratePerYearRemain  = (_ratePerYearRemain.length > 0 ? _ratePerYearRemain : "0");
                _invoiceAmount      = (_invoiceAmount.length > 0 ? _invoiceAmount : "0");
                _amount             = (_amount.length > 0 ? _amount : "0");
                _tuition            = (_tuition.length > 0 ? _tuition : "0");

                _ratePerYearRemain  = (parseFloat(_ratePerYearRemain) + (parseFloat(_amount) - parseFloat(_tuition)));
                _ratePerYearRemain  = _ratePerYearRemain.toLocaleString(undefined, {
                                        minimumFractionDigits: 2,
                                        maximumFractionDigits: 2
                                      });

                _stdPayAmount       = (parseFloat(_invoiceAmount) - parseFloat(_tuition));
                _stdPayAmount       = _stdPayAmount.toLocaleString(undefined, {
                                        minimumFractionDigits: 2,
                                        maximumFractionDigits: 2
                                      });
                _stdPayAmount       = (Util.blockCharNotWanted(_invoiceAmount).length == 0 && 
                                       Util.blockCharNotWanted(_tuition).length == 0 &&
                                       Util.blockCharNotWanted(_stdPayAmount) == 0 ? "" : _stdPayAmount);

                $("#" + _this.idContent + "-rateperyearremain").val(Util.blockCharNotWanted(_ratePerYearRemain));
                $("#" + _this.idContent + "-stdpayamount").val(Util.blockCharNotWanted(_stdPayAmount));
            },

            validate: function (_callBackFunc) {
                var _this = this;
                var _error = new Array();
                var _i = 0;
                var _data = _this.value();
                _data.cmd = "gettranstudent";

                Util.msgPreloading = "Validating...";

                Util.actionTask({
                    action: "get",
                    data: _data
                }, function (_result) {
                    var _id                 = (_result.PersonId + "|" + _result.ScholarshipsYear + "|" + _result.Semester + "|" + _result.ScholarshipsId);
                    var _personId           = _result.PersonId;
                    var _scholarshipsYear   = _result.ScholarshipsYear;
                    var _semester           = _result.Semester;
                    var _scholarshipsId     = _result.ScholarshipsId;
                    var _invoiceNo          = _result.InvoiceNo;
                    var _totalCredit        = Util.blockCharNotWanted(_result.TotalCredit);
                    var _ratePerYear        = Util.blockCharNotWanted(_result.RatePerYear);
                    var _ratePerYearRemain  = _result.RatePerYearRemain;
                    var _registerDate       = _result.RegisterDate;
                    var _contractDate       = _result.ContractDate;
                    var _invoiceAmount      = Util.delCommas("#" + _this.idContent + "-invoiceamount");
                    var _tuition            = Util.delCommas("#" + _this.idContent + "-amount");

                    $("#" + _this.idContent + "-id-hidden").val(_id);
                    $("#" + _this.idContent + "-personid-hidden").val(_personId);
                    $("#" + _this.idContent + "-scholarshipsyear-hidden").val(_scholarshipsYear);
                    $("#" + _this.idContent + "-semester-hidden").val(_semester);
                    $("#" + _this.idContent + "-scholarshipsid-hidden").val(_scholarshipsId);
                    $("#" + _this.idContent + "-scholarshipsyearsemester").val(_scholarshipsYear + " / " + _semester);
                    $("#" + _this.idContent + "-invoiceno").val(_invoiceNo);
                    $("#" + _this.idContent + "-totalcredit").val(_totalCredit);
                    $("#" + _this.idContent + "-rateperyear").val(_ratePerYear.length > 0 ? parseFloat(_ratePerYear).toLocaleString(undefined, {
                                                                                                minimumFractionDigits: 2,
                                                                                                maximumFractionDigits: 2
                                                                                            }) : "");
                    $("#" + _this.idContent + "-rateperyearremain-hidden").val(_ratePerYearRemain);

                    _this.calculate();

                    if (_personId.length == 0 || _scholarshipsYear.length == 0 || _semester.length == 0 || _scholarshipsId.length == 0 || _registerDate.length == 0) { _error[_i] = ("ไม่พบข้อมูล;Data not found.;"); _i++; }
                    if (_personId.length  > 0 && _scholarshipsYear.length  > 0 && _semester.length  > 0 && _scholarshipsId.length  > 0 && _registerDate.length  > 0 && _contractDate.length == 0) { _error[_i] = ("ไม่พบข้อมูลวันทำสัญญา;Contract date not found.;"); _i++; }
                    //if (_invoiceNo.length == 0)     { _error[_i] = ("ไม่พบหมายเลขใบแจ้งหนี้;Invoice number not found.;"); _i++; }
                    //if (_totalCredit.length == 0)   { _error[_i] = ("ไม่พบหน่วยกิตที่ลงทะเบียน;Total credit not found.;"); _i++; }
                    if (_ratePerYear.length == 0)   { _error[_i] = ("ไม่พบเงินกู้ที่สามารถกู้ได้ต่อปี;Loan rate per year not found.;"); _i++; }
                    if (_invoiceAmount.length == 0) { _error[_i] = ("กรุณาระบุค่าลงทะเบียนไม่รวมค่าหอพัก;Please enter Registration Fee Not Include Dormitory Fee.;"); _i++; }
                    if (_tuition.length == 0)       { _error[_i] = ("กรุณาระบุจำนวนเงินที่ขอกู้;Please enter amount of loan.;"); _i++; }
                    if (_ratePerYearRemain.length > 0 && _invoiceAmount.length > 0 && _tuition.length > 0)
                    {
                        _ratePerYearRemain  = parseFloat(_ratePerYearRemain);
                        _invoiceAmount      = parseFloat(_invoiceAmount);
                        _tuition            = parseFloat(_tuition);

                        _ratePerYearRemain  = (_tuition > _ratePerYearRemain ? (Util.delCommas("#" + _this.idContent + "-rateperyearremain").length == 0 ? 0 : parseFloat(Util.delCommas("#" + _this.idContent + "-rateperyearremain"))) : _ratePerYearRemain);

                        if (_tuition > _invoiceAmount || _tuition > _ratePerYearRemain)
                        {
                            _error[_i] = ("ไม่สามารถระบุจำนวนเงินที่ขอกู้มากกว่าค่าลงทะเบียนหรือเงินกู้คงเหลือที่สามารถกู้ได้ต่อปี;Can not be specified amount of loan more than registration fee or balance amount of loan per year.;");
                            _i++;
                        }
                    }

                    Util.dialogListMessageError({
                        content: _error
                    });

                    _callBackFunc(_i > 0 ? false : true);
                });
            },

            value: function () {
                var _this = this;
                var _data = {};

                _data.id                = $("#" + _this.idContent + "-id-hidden").val();
                _data.personId          = $("#" + _this.idContent + "-personid-hidden").val();
                _data.scholarshipsYear  = $("#" + _this.idContent + "-scholarshipsyear-hidden").val();
                _data.semester          = $("#" + _this.idContent + "-semester-hidden").val();
                _data.scholarshipsId    = $("#" + _this.idContent + "-scholarshipsid-hidden").val();
                _data.invoiceNo         = $("#" + _this.idContent + "-invoiceno").val();
                _data.regisCredit       = $("#" + _this.idContent + "-totalcredit").val();
                _data.ratePerYear       = Util.delCommas("#" + _this.idContent + "-rateperyear");
                _data.ratePerYearRemain = Util.delCommas("#" + _this.idContent + "-rateperyearremain");
                _data.invoiceAmount     = Util.delCommas("#" + _this.idContent + "-invoiceamount");
                _data.tuition           = Util.delCommas("#" + _this.idContent + "-amount");
                _data.stdPayAmount      = Util.blockCharNotWanted(Util.delCommas("#" + _this.idContent + "-stdpayamount"));

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

                    $("#" + _this.idContent + "-saveresult").val(_error == false ? "Y" : "N");
                    
                    if (_error == false)
                    {
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
    }
}