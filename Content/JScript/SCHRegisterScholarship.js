var SCHRegisterScholarship = {
    main: {
        idContent: ("main-" + SCHUtil.subjectRegisterScholarship.toLowerCase()),

        init: function () {
            var _this = this;

            Util.trs.search.init();
        }
    },

    search: {
        idContent: ("search-" + SCHUtil.subjectRegisterScholarship.toLowerCase()),

        init: function () {
            var _this = this;

            Util.initShrinkPanel({
                id: ("#" + _this.idContent)
            });
            Util.initDropdown({
                id: ("#" + _this.idContent)
            }, function (_result) {
                Util.trs.list.clear();
            });

            $("#" + _this.idContent + " .button").click(function () {
                var _idContent = $(this).attr("id");

                $(this).blur();

                if (_idContent == (_this.idContent + "-btnsearch"))
                {
                    if (_this.validate())
                    {                    
                        _this.action(function () {
                            Util.gotoElement({
                                anchorName: ("#" + Util.trs.list.idContent),
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
            var _error = new Array();
            var _i = 0;

            return (_i > 0 ? false : true);
        },

        value: function () {
            var _this = this;
            var _data = {};

            _data.keyword   = $("#main-keyword").val();
            _data.facultyId = Util.getSelectionIsSelect({
                                id: ("#" + _this.idContent + "-faculty"),
                                type: "select",
                                valueTrue: Util.getDropdrownValue({
                                    id: ("#" + _this.idContent + "-faculty")
                                })
                              });
            _data.programId = Util.getSelectionIsSelect({
                                id: ("#" + _this.idContent + "-program"),
                                type: "select",
                                valueTrue: Util.getDropdrownValue({
                                    id: ("#" + _this.idContent + "-program")
                                })
                              });
            _data.yearEntry = Util.getSelectionIsSelect({
                                id: ("#" + _this.idContent + "-yearentry"),
                                type: "select",
                                valueTrue: Util.getDropdrownValue({
                                    id: ("#" + _this.idContent + "-yearentry")
                                })
                              });

            return _data;
        },

        action: function (_callBackFunc) {
            var _this = this;
            var _data = {};
       
            Util.trs.list.clear();

            _data = _this.value();
        
            Util.msgPreloading = "Searching...";

            Util.actionTask({
                action: "search",
                page: Util.pageRegisterScholarshipMain,
                data: _data
            }, function (_result) {
                $("#" + Util.trs.list.idContent).html(_result.List);
                $("#" + Util.trs.list.idContent + " .recordcountprimary-search").html(_result.RecordCountPrimary);
                $("#" + Util.trs.list.idContent + " .table-navpage").html(_result.NavPage);

                Util.setBodyLayout();
                Util.setLanguageOnForm({
                    id: ("#" + Util.trs.list.idContent)
                });

                Util.trs.list.init();
                _callBackFunc();
            });
        }
    },

    list: {
        idContent: ("list-" + SCHUtil.subjectRegisterScholarship.toLowerCase()),

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
                var _personId;
                var _idContent;

                $(this).blur();
            
                if ($(this).hasClass("btnstudentcv"))
                {                
                    _personId   = $(this).data("options");
                    _idContent  = (_this.idContent + "-studentcv-" + _personId);

                    $("#" + _this.idContent + " table tr.ui." + Util.subjectStudentCV.toLowerCase() + " td").html("");
                    $("#" + _this.idContent + " table tr.ui." + Util.subjectStudentCV.toLowerCase()).addClass("hide").hide();
                    $("#" + _idContent).removeClass("hide").show();

                    Util.loadForm({
                        name: Util.pageRegisterScholarshipStudentCVMain,
                        data: $(this).data("options"),
                        showPreloadingInline: true,
                        idPreloadingInline: (Util.trs.studentCV.idContent + "-id-" + _personId),
                        id: ("#" + Util.trs.studentCV.idContent + "-id-" + _personId)
                    }, function (_result) {                    
                        if (_result.MainContent.length > 0)
                            Util.trs.studentCV.init({
                                data: _personId
                            });
                        else
                            $("#" + _idContent).addClass("hide").hide();
                    });
                }
            });

            $("#" + _this.idContent + " .btnregister-option").click(function () {
                var _option = $(this).attr("alt");

                $(this).blur();
                
                if (_this.option.register.validate({
                        option: _option
                    }))
                {
                    Util.loadForm({
                        name: Util.pageRegisterScholarshipAddUpdate,
                        dialog: true,
                    }, function (_result, _e) {
                        if (_result.MainContent.length > 0)
                            Util.trs.addupdate.init({
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
            register: {
                validate: function (_param) {
                    _param.option = (_param.option == undefined ? "" : _param.option);

                    var _this = this;
                    var _error = false;
                    var _msgTH;
                    var _msgEN;
                    var _objCheck = $("#" + Util.trs.list.idContent + " table" + " .select-child:checked");

                    if (_error == false && _param.option == "selected" && _objCheck.length == 0) { _error = true; _msgTH = "กรุณาเลือกรายการ"; _msgEN = "Please select item."; }

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
            },
        },
    },

    studentCV: {
        idContent: ("main-" + SCHUtil.subjectRegisterScholarshipStudentCV.toLowerCase()),

        init: function (_param) {
            _param.data = (_param.data == undefined ? "" : _param.data)

            var _this = this;
            var _personId = _param.data;
            var _idContent = (_this.idContent + "-id-" + _personId);

            Util.initClosePanel({
                id: ("#" + _idContent),
                hide: true,
                idHide: ("#" + Util.trs.list.idContent + "-studentcv-" + _personId)
            }, function () { });
            
            _this.reset({
                data: _personId
            });
        },

        reset: function (_param) {
            _param.data = (_param.data == undefined ? "" : _param.data)

            var _this = this;
            var _personId = _param.data;

            Util.getStudentPicture({
                src: $("#" + _this.idContent + "-studentpicture-hidden").val()
            });
        }
    },

    addupdate: {
        idContent: ("addupdate-" + SCHUtil.subjectRegisterScholarship.toLowerCase()),

        init: function (_param) {
            _param.option = (_param.option == undefined ? "" : _param.option);

            var _this = this;
            var _data = {};
            var _selected;
            var _paramSearch;
        
            Util.initDropdown({
                id: ("#" + _this.idContent)
            }, function (_result) {
            });
            Util.initCalendar({
                id: ("#" + _this.idContent + "-registerdate")
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
                            {
                                var _data = _this.value();

                                if (_param.option == "selected")
                                {
                                    _selected       = Util.getValueSelectCheck({
                                                        id: "select-child",
                                                        idParent: ("#" + Util.trs.list.idContent + " table")
                                                      }).join("|");
                                    _paramSearch    = "";
                                }

                                if (_param.option == "all")
                                {
                                    _selected       = "";
                                    _paramSearch    = (JSON.stringify(Util.trs.search.value())).replace(/({|}|")/g, "");
                                }
                                                         
                                _data.option        = _param.option;
                                _data.selected      = _selected;
                                _data.paramSearch   = _paramSearch;

                                _this.action({
                                    page: _page,                                
                                    data: _data
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
            var _recordCount = ($("#" + Util.trs.list.idContent + " .table-title .recordcountprimary-search").length > 0 ? $("#" + Util.trs.list.idContent + " .table-title .recordcountprimary-search:eq(0)").html() : "");
            var _objCheck = $("#" + Util.trs.list.idContent + " table" + " .select-child:checked");
            var _dataCount;

            if (_param.option == "selected")    _dataCount = _objCheck.length;
            if (_param.option == "all")         _dataCount = (_recordCount.length > 0 && _recordCount != "0" ? _recordCount : "0");
        
            $("#" + _this.idContent + " .view .total").html(_dataCount);
            $("#" + _this.idContent + " .view .totalcomplete, " +
              "#" + _this.idContent + " .view .totalincomplete").html("");
            $("#" + _this.idContent + " .view .totalunit, " +
              "#" + _this.idContent + " .view .totalunit").hide();
        },

        validate: function () {
            var _this = this;
            var _error = new Array();
            var _scholarshipsYear = Util.getDropdrownValue({ id: ("#" + _this.idContent + "-scholarshipsyear") });
            var _semester = Util.getDropdrownValue({ id: ("#" + _this.idContent + "-semester") });
            var _registerDate = Util.getCalendarValue({ id: ("#" + _this.idContent + "-registerdate") });
            var _scholarshipsId = Util.getDropdrownValue({ id: ("#" + _this.idContent + "-scholarships") });
            var _responsibleAgency = $("#" + _this.idContent + "-responsibleagency").val();
            var _i = 0;

            if (_scholarshipsYear == "0")       { _error[_i] = ("กรุณาเลือกปีที่สมัครรับทุน;Please select scholarship year.;"); _i++; }
            if (_semester == "0")               { _error[_i] = ("กรุณาเลือกภาคเรียน;Please select semester.;"); _i++; }
            if (_registerDate.length == 0)      { _error[_i] = ("กรุณาระบุวันที่สมัครรับทุน;Please enter register date.;"); _i++; }
            if (_scholarshipsId == "0")         { _error[_i] = ("กรุณาเลือกทุน;Please select scholarship.;"); _i++; }
            if (_responsibleAgency.length == 0) { _error[_i] = ("กรุณาระบุหน่วยงานที่รับผิดขอบ;Please enter Responsible Agency."); _i++; }

            Util.dialogListMessageError({
                content: _error
            });

            return (_i > 0 ? false : true);
        },

        value: function () {
            var _this = this;
            var _data = {};
        
            _data.scholarshipsYear  = Util.getSelectionIsSelect({
                                        id: ("#" + _this.idContent + "-scholarshipsyear"),
                                        type: "select",
                                        valueTrue: Util.getDropdrownValue({
                                            id: ("#" + _this.idContent + "-scholarshipsyear")
                                        })
                                      });
            _data.semester          = Util.getSelectionIsSelect({
                                        id: ("#" + _this.idContent + "-semester"),
                                        type: "select",
                                        valueTrue: Util.getDropdrownValue({
                                            id: ("#" + _this.idContent + "-semester")
                                        })
                                      });
            _data.registerDate      = Util.getCalendarValue({ id: ("#" + _this.idContent + "-registerdate") });
            _data.scholarshipsId    = Util.getSelectionIsSelect({
                                        id: ("#" + _this.idContent + "-scholarships"),
                                        type: "select",
                                        valueTrue: Util.getDropdrownValue({
                                            id: ("#" + _this.idContent + "-scholarships")
                                        })
                                      });
            _data.responsibleAgency = $("#" + _this.idContent + "-responsibleagency").val();

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
}