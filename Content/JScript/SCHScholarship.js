var SCHScholarship = {
    main: {
        idContent: ("main-" + SCHUtil.subjectScholarship.toLowerCase()),
        firstLoad: true,

        init: function () {
            var _this = this;

            $("#" + _this.idContent + " .button").click(function () {
                var _idContent = $(this).attr("id");

                $(this).blur();

                if (_idContent == (_this.idContent + "-btnadd"))
                {
                    Util.loadForm({
                        name: Util.pageScholarshipAdd,
                        id: ("#" + Util.tsl.addupdate.idContent)
                    }, function (_result) {
                        Util.tsl.addupdate.init();
                    });
                }
            });

            Util.tsl.search.init();
            $("#" + Util.tsl.search.idContent + " .button").click();
        }
    },

    search: {
        idContent: ("search-" + SCHUtil.subjectScholarship.toLowerCase()),

        init: function () {
            var _this = this;
        
            Util.initShrinkPanel({
                id: ("#" + _this.idContent)
            });
            Util.initDropdown({
                id: ("#" + _this.idContent)
            }, function (_result) {
                Util.tsl.list.clear();
            });

            $("#" + _this.idContent + " .button").click(function () {
                var _idContent = $(this).attr("id");

                $(this).blur();
            
                if (_idContent == (_this.idContent + "-btnsearch"))
                {
                    if (_this.validate())
                    {                    
                        _this.action(function () {
                            if (Util.tsl.main.firstLoad == false)
                            {
                                Util.gotoElement({
                                    anchorName: ("#" + Util.tsl.list.idContent),
                                    top: ($("#followingmenu").outerHeight())
                                });
                            }

                            Util.tsl.main.firstLoad = false;
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

            _data.keyword               = $("#main-keyword").val();
            _data.scholarshipsTypeId    = Util.getSelectionIsSelect({
                                            id: ("#" + _this.idContent + "-scholarshipstype"),
                                            type: "select",
                                            valueTrue: Util.getDropdrownValue({
                                                id: ("#" + _this.idContent + "-scholarshipstype")
                                            })
                                          });

            return _data;
        },

        action: function (_callBackFunc) {
            var _this = this;
            var _data = {};
       
            Util.tsl.list.clear();

            _data = _this.value();
            
            Util.msgPreloading = "Searching...";

            Util.actionTask({
                action: "search",
                page: Util.pageScholarshipMain,
                data: _data
            }, function (_result) {
                $("#" + Util.tsl.list.idContent).html(_result.List);
                $("#" + Util.tsl.list.idContent + " .recordcountprimary-search").html(_result.RecordCountPrimary);

                Util.setBodyLayout();
                Util.setLanguageOnForm({
                    id: ("#" + Util.tsl.list.idContent)
                });

                Util.tsl.list.init();
                _callBackFunc();
            });
        }
    },

    list: {
        idContent: ("list-" + SCHUtil.subjectScholarship.toLowerCase()),

        init: function () {
            var _this = this;
            var _data = {};

            Util.initDropdown({
                id: ("#" + _this.idContent),
            }, function (_result) {
            });

            $("#" + _this.idContent + " .item").click(function () {
                $(this).blur();
            
                if ($(this).hasClass("btnupdate"))
                {                
                    Util.loadForm({
                        name: Util.pageScholarshipUpdate,
                        data: $(this).data("options"),
                        id: ("#" + Util.tsl.addupdate.idContent)
                    }, function (_result) {
                        if (_result.MainContent.length > 0)
                            Util.tsl.addupdate.init()
                    });
                }

                if ($(this).hasClass("btnsetactive"))
                {
                    _data.id                = $(this).data().id;
                    _data.approvalStatus    = $(this).data().status;
                    
                    Util.tsl.addupdate.action({
                        page: Util.pageScholarshipUpdate,
                        data: _data
                    });
                }
            });
        },

        clear: function () {
            var _this = this;

            $("#" + Util.tsl.addupdate.idContent).html("");
            $("#" + _this.idContent).html("");
            Util.setBodyLayout();
        }
    },

    addupdate: {
        idContent: ("addupdate-" + SCHUtil.subjectScholarship.toLowerCase()),

        init: function () {
            var _this = this;
            var _page;

            Util.initClosePanel({
                id: ("#" + _this.idContent)
            }, function () { });
            Util.initDropdown({
                id: ("#" + _this.idContent)
            }, function (_result) {
            });

            $("input:text").keypress(function (_e) {
                var _idContent = $(this).attr("id");

                if (_idContent == (_this.idContent + "-scholarshipsnameth")) return Util.blockEnglish(this, _e);
                if (_idContent == (_this.idContent + "-scholarshipsnameen")) return Util.blockNonEnglishAndNumeric(this, _e);
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

            _this.reset();
        },

        reset: function () {
            var _this = this;

            Util.gotoElement({
                anchorName: ("#" + _this.idContent),
                top: ($("#followingmenu").outerHeight())
            });

            $("#" + _this.idContent + "-scholarshipsnameth").val($("#" + _this.idContent + "-scholarshipsnameth-hidden").val());
            $("#" + _this.idContent + "-scholarshipsnameen").val($("#" + _this.idContent + "-scholarshipsnameen-hidden").val());
            $("#" + _this.idContent + "-scholarshipstype").dropdown("set selected", $("#" + _this.idContent + "-scholarshipstype-hidden").val());
            $("#" + _this.idContent + "-owner").val($("#" + _this.idContent + "-owner-hidden").val());
        },

        validate: function () {
            var _this = this;
            var _error = new Array();
            var _nameTH = $("#" + _this.idContent + "-scholarshipsnameth").val();
            var _i = 0;

            if (_nameTH.length < 3) { _error[_i] = ("กรุณาระบุชื่อทุนไม่ต่ำกว่า 3 ตัวอักษร;Please enter scholar thai name more then 3 characters.;"); _i++ }

            Util.dialogListMessageError({
                content: _error
            });

            return (_i > 0 ? false : true);
        },

        value: function () {
            var _this = this;
            var _data = {};

            _data.id                    = $("#" + _this.idContent + "-id-hidden").val();
            _data.scholarshipsNameTH    = $("#" + _this.idContent + "-scholarshipsnameth").val();
            _data.scholarshipsNameEN    = $("#" + _this.idContent + "-scholarshipsnameen").val();
            _data.scholarshipsTypeId    = Util.getSelectionIsSelect({
                                            id: ("#" + _this.idContent + "-scholarshipstype"),
                                            type: "select",
                                            valueTrue: Util.getDropdrownValue({
                                                id: ("#" + _this.idContent + "-scholarshipstype")
                                            })
                                          });
            _data.owner                 = $("#" + _this.idContent + "-owner").val();
            _data.approvalStatus        = $("#" + _this.idContent + "-approvalstatus-hidden").val();

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
                    Util.tsl.search.action(function () {
                        Util.gotoElement({
                            anchorName: ("#" + Util.tsl.list.idContent + "-id-" + _result.Id),
                            top: ($("#followingmenu").outerHeight())
                        });

                        Util.dialogMessage({
                            type: "info",
                            msgTH: "บันทึกข้อมูลเรียบร้อย",
                            msgEN: "Save complete."
                        }, function () { });
                    });
                }
            });
        }
    }
}