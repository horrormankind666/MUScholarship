var SCHImportRegisterScholarship = {
    main: {
        idContent: ("main-" + SCHUtil.subjectImportRegisterScholarship.toLowerCase()),

        init: function () {
            var _this = this;

            Util.tis.import.init();
        }
    },

    import: {
        idContent: ("import-" + SCHUtil.subjectImportRegisterScholarship.toLowerCase()),
        supportFileType: "xls, xlsx",

        init: function () {
            var _this = this;

            Util.initShrinkPanel({
                id: ("#" + _this.idContent)
            });
            Util.initBrowseFile({
                id: ("#" + _this.idContent)
            }, function (_result) {
                Util.tis.list.clear();
            });

            $("#" + Util.tis.main.idContent + " .button").click(function () {
                var _idContent = $(this).attr("id");
                
                $(this).blur();

                if (_idContent == (Util.tis.main.idContent + "-btndownload"))
                    Util.viewFile({
                        url: ("../Module/SCHDownloadFile.aspx?action=" + Util.subjectRegisterScholarshipTemplate)
                    });

                if (_idContent == (_this.idContent + "-btnimport"))
                {
                    if (_this.validate())
                    {
                        _this.action(function () {
                            Util.gotoElement({
                                anchorName: ("#" + Util.tis.list.idContent),
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
            var _relativeFile = $("#" + _this.idContent + "-relativefile").val().split(".");
            var _absoluteFile = $("#" + _this.idContent + "-absolutefile")[0].files[0];            
            var _i = 0;

            if (_relativeFile.length < 2) { _error[_i] = ("กรุณาเลือกไฟล์;Please browse to select a file.;"); _i++; }
            if (_this.supportFileType.indexOf(_relativeFile[_relativeFile.length - 1]) < 0) { _error[_i] = ("นามสกุลของไฟล์ไม่ถูกต้อง;Invalid file type.;"); _i++; }
            if (_i == 0)
            {
                var _f = new FormData();

                _f.append("file", _absoluteFile);
                
                if (_absoluteFile.size <= 0)
                {
                    _error[_i] = ("ไม่พบขนาดไฟล์;File size not found.;");
                    _i++;
                }
            }

            Util.dialogListMessageError({
                content: _error
            });

            return (_i > 0 ? false : true);        
        },

        value: function () {
            var _this = this;
            var _data = {};

            _data.absoluteFile = $("#" + _this.idContent + "-absolutefile")[0].files[0];

            return _data;
        },

        action: function (_callBackFunc) {
            var _this = this;
            var _data = {};
            var _f = new FormData();
       
            Util.tis.list.clear();

            _data = _this.value();
            _f.append("file", _data.absoluteFile);            
            
            Util.msgPreloading = "Importing...";

            Util.ajaxUploadFile({
                url: ("../Module/SCHUploadFile.aspx?" +
                      "action=" + Util.subjectImportRegisterScholarship),
                method: "POST",
                data: _f

            }, function (_result) {
                var _result = $.parseJSON(_result);
                var _error;

                _error = Util.getErrorMsg({
                    signinYN: _result.SignInYN,
                    cookieError: _result.CookieError,
                    userError: _result.UserError,
                    saveError: _result.UploadFileError
                });
            
                if (_error == false)
                {
                    $("#" + Util.tis.list.idContent).html(_result.MainContent);

                    Util.setBodyLayout();
                    Util.setLanguageOnForm({
                        id: ("#" + Util.tis.list.idContent)
                    });

                    Util.tis.list.init();
                    _callBackFunc();
                }
            });
        }
    },

    list: {
        idContent: ("list-" + SCHUtil.subjectImportRegisterScholarship.toLowerCase()),

        init: function () {
            var _this = this;
            var _data = {};

            Util.initCheck({
                id: ("#" + _this.idContent + " .checkbox")
            });
            for (_i = 0; _i < $("#" + _this.idContent + " table thead th").length; _i++) {
                Util.initTooltip({
                    id: ("#" + _this.idContent + " table td.col" + (_i + 1))
                });
            }
            Util.initTable({
                id: ("#" + _this.idContent + " table")
            });

            $("#" + _this.idContent + " .button").click(function () {
                var _option = "selected";
                var _data = {};
                var _idContent;            

                $(this).blur();
            
                if ($(this).hasClass("btnstudentcv"))
                {                                
                    Util.tis.studentCV.form({
                        data: $(this).data("options"),
                        idParent: _this.idContent,
                        idMain: Util.tis.studentCV.idContent
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
                        name: Util.pageImportRegisterScholarshipAddUpdate,
                        dialog: true,
                    }, function (_result, _e) {
                        if (_result.MainContent.length > 0)
                            Util.tis.addupdate.init({
                                option: _option
                            });
                    });
                }
            });

            _this.reset();
        },

        reset: function () {        
            var _this = this;            
            var _recordCount = $("#" + _this.idContent + " table td .checkbox").length;

            if (_recordCount == 0)
                $("#" + _this.idContent + " .table-title .btnoption").addClass("disabled");
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
                    var _objCheck = $("#" + Util.tis.list.idContent + " table" + " .select-child:checked");

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
        idContent: ("main-" + SCHUtil.subjectImportRegisterScholarship.toLowerCase()),
        
        form: function (_param) {
            _param.data     = (_param.data == undefined || _param.data == "" ? {} : _param.data);
            _param.idParent = (_param.idParent == undefined ? "" : _param.idParent);
            _param.idMain   = (_param.idMain == undefined ? "" : _param.idMain);

            var _this = this;
            var _id = (_param.data.personId + _param.data.scholarshipsYear + _param.data.semester + _param.data.scholarshipsId);
            var _idParent = (_param.idParent + "-studentcv-" + _id);
            var _idMain = (_param.idMain + "-id-" + _id)     
        
            $("#" + _param.idParent + " table tr.ui." + Util.subjectStudentCV.toLowerCase() + " td").html("");
            $("#" + _param.idParent + " table tr.ui." + Util.subjectStudentCV.toLowerCase()).addClass("hide").hide();
            $("#" + _idParent).removeClass("hide").show();
        
            Util.loadForm({
                name: Util.pageImportRegisterScholarshipStudentCVMain,
                data: (_param.data.personId + "|" + _param.data.scholarshipsYear + "|" + _param.data.semester + "|" + _param.data.scholarshipsId),
                showPreloadingInline: true,
                idPreloadingInline: _idMain,
                id: ("#" + _idMain)
            }, function (_result) {
                if (_result.MainContent.length > 0)
                    _this.init({
                        idParent: ("#" + _idParent),
                        idMain: ("#" + _idMain)
                    });
                else
                    $("#" + _idParent).addClass("hide").hide();
            });
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
            
            _this.reset({
                id: _param.idMain
            });
        },

        reset: function (_param) {
            _param.id = (_param.id == undefined ? "" : _param.id);

            var _this = this;
            var _idContent = _param.id.replace(_this.idContent, Util.tis.list.idContent);

            Util.getStudentPicture({
                id: _param.id,
                src: $(_param.id + " .studentpicture-hidden").val()
            });
            
            $(_param.id + " .iform .col2 .iform-row:eq(5) .col22 span:eq(0)").html($(_idContent + " .col5 span:eq(0)").html());
            $(_param.id + " .iform .col2 .iform-row:eq(5) .col22 span:eq(1)").html($(_idContent + " .col5 span:eq(1)").html());
            $(_param.id + " .iform .col2 .iform-row:eq(5) .col22 span:eq(2)").html($(_idContent + " .col5 span:eq(2)").html());
            $(_param.id + " .iform .col2 .iform-row:eq(5) .col22 span:eq(3)").html($(_idContent + " .col5 span:eq(3)").html());

            $(_param.id + " .iform .col2 .iform-row:eq(6) .col22 span:eq(0)").html($(_idContent + " .col6 span:eq(0)").html());
            $(_param.id + " .iform .col2 .iform-row:eq(6) .col22 span:eq(1)").html($(_idContent + " .col6 span:eq(1)").html());

            $(_param.id + " .iform .col2 .iform-row:eq(7) .col22 span:eq(0)").html($(_idContent + " .col8 span:eq(0)").html());
            $(_param.id + " .iform .col2 .iform-row:eq(7) .col22 span:eq(1)").html($(_idContent + " .col8 span:eq(0)").html());
        }
    },

    addupdate: {
        idContent: ("addupdate-" + SCHUtil.subjectImportRegisterScholarship.toLowerCase()),

        init: function (_param) {
            _param.option = (_param.option == undefined ? "" : _param.option);

            var _this = this;
            var _data = {};
            var _selected;
            var _paramSearch;
        
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
                                                        idParent: ("#" + Util.tis.list.idContent + " table")
                                                      }).join("|");
                                    _paramSearch    = "";
                                }
                                
                                if (_param.option == "all")
                                {
                                    var _idCheck = $("#" + Util.tis.list.idContent + " table td .checkbox");
                                    var _countCheck = _idCheck.length;
                                    var _valueCheck = new Array();

                                    if (_countCheck > 0)
                                    {
                                        _idCheck.each(function (_i) {
                                            _valueCheck[_i] = this.value;
                                        });
                                    }

                                    _selected       = _valueCheck.join("|");
                                    _paramSearch    = ""
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
            var _recordCount = $("#" + Util.tis.list.idContent + " table td .checkbox").length;
            var _objCheck = $("#" + Util.tis.list.idContent + " table" + " .select-child:checked");
            var _dataCount;

            if (_param.option == "selected")    _dataCount = _objCheck.length;
            if (_param.option == "all")         _dataCount = _recordCount;
        
            $("#" + _this.idContent + " .view .total").html(_dataCount);
            $("#" + _this.idContent + " .view .totalcomplete, " +
              "#" + _this.idContent + " .view .totalincomplete").html("");
            $("#" + _this.idContent + " .view .totalunit, " +
              "#" + _this.idContent + " .view .totalunit").hide();
        },
        
        validate: function () {
            var _this = this;
            var _error = new Array();
            var _registerDate = Util.getCalendarValue({ id: ("#" + _this.idContent + "-registerdate") });
            var _i = 0;

            if (_registerDate.length == 0) { _error[_i] = ("กรุณาระบุวันที่สมัครรับทุน;Please enter register date.;"); _i++; }

            Util.dialogListMessageError({
                content: _error
            });

            return (_i > 0 ? false : true);
        },

        value: function () {
            var _this = this;
            var _data = {};
        
            _data.registerDate = Util.getCalendarValue({ id: ("#" + _this.idContent + "-registerdate") });

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