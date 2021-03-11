/// <summary>
/// Auther : Odd.Nopparat
/// Date   : 2015-08-20.
/// Perpose: สลับภาษาอังกฤษ.
/// Method : english-active.
/// </summary>
function thaiAcitive() {    
    $('.lang-active').data('lang', 'th');
    $('.en').addClass('hide');
    $('.th, .thai').removeClass('hide');
}
// english active
function engAcitive() {
    $('.lang-active').data('lang', 'en');
    $('.th').addClass('hide');
    $('.en, .thai').removeClass('hide');
}
// memory of language
function memoryLanguage() {    
    if ($('.lang-active').data('lang') == 'th') {
        thaiAcitive();        
    }
    if ($('.lang-active').data('lang') == 'en') {
        engAcitive();
    }
}

/// <summary>
/// Auther : Nopparat.j
/// Date   : 2014-12-01.
/// Perpose: ทำเพจจิ้ง.
/// Method : -
/// Sample : -
/// </summary>
var g_currentpage = 0;
function tablePagination() {
    $('.table-driller').each(function () {
        var currentPage = 0;
        var numPerPage = 20;
        g_numPerPage = numPerPage;
        var $table = $(this);
        $table.bind('repaginate', function () {
            $table.find('tbody tr').hide().slice(currentPage * numPerPage, (currentPage + 1) * numPerPage).show();
            g_currentPage = (currentPage * numPerPage, (currentPage + 1) * numPerPage);
            $('tbody tr').addClass('p_' + g_currentpage);
        });

        $table.trigger('repaginate');
        var numRows = $table.find('tbody tr').length;
        g_numRow = numRows;
        var numPages = Math.ceil(numRows / numPerPage);

        var $pager = $('<div class="pager"></div>');
        for (var page = 0; page < numPages; page++) {
            $('<span class="page-number"></span>').text(page + 1).bind('click', {
                newPage: page
            }, function (event) {
                currentPage = event.data['newPage'];
                g_currentpage = currentPage;
                $table.trigger('repaginate');
                $(this).addClass('active').siblings().removeClass('active');
            }).appendTo($pager).addClass('clickable');
        }
        $pager.insertAfter($table).find('span.page-number:first').addClass('active');
    });
}


// original code from http://stackoverflow.com/questions/13478303/correct-way-to-use-modernizr-to-detect-ie
var BrowserDetect = {
    init: function () {
        this.browser = this.searchString(this.dataBrowser) || "Other";
        this.version = this.searchVersion(navigator.userAgent) || this.searchVersion(navigator.appVersion) || "Unknown";
    },
    searchString: function (data) {
        for (var i = 0; i < data.length; i++) {
            var dataString = data[i].string;
            this.versionSearchString = data[i].subString;

            if (dataString.indexOf(data[i].subString) !== -1) {
                return data[i].identity;
            }
        }
    },
    searchVersion: function (dataString) {
        var index = dataString.indexOf(this.versionSearchString);
        if (index === -1) {
            return;
        }

        var rv = dataString.indexOf("rv:");
        if (this.versionSearchString === "Trident" && rv !== -1) {
            return parseFloat(dataString.substring(rv + 3));
        } else {
            return parseFloat(dataString.substring(index + this.versionSearchString.length + 1));
        }
    },

    dataBrowser: [
        { string: navigator.userAgent, subString: "Edge", identity: "MS Edge" },
        { string: navigator.userAgent, subString: "Chrome", identity: "Chrome" },
        { string: navigator.userAgent, subString: "MSIE", identity: "Explorer" },
        { string: navigator.userAgent, subString: "Trident", identity: "Explorer" },
        { string: navigator.userAgent, subString: "Firefox", identity: "Firefox" },
        { string: navigator.userAgent, subString: "Safari", identity: "Safari" },
        { string: navigator.userAgent, subString: "Opera", identity: "Opera" }
    ]

};

BrowserDetect.init();
if (BrowserDetect.browser == 'Chrome' && BrowserDetect.version <= 42) goBlankPage();
if (BrowserDetect.browser == 'Explorer' && BrowserDetect.version <= 9) goBlankPage();
if (BrowserDetect.browser == 'Firefox' && BrowserDetect.version <= 39) goBlankPage();
if (BrowserDetect.browser == 'Opera' && BrowserDetect.version <= 31) goBlankPage();
if (BrowserDetect.browser == 'Safari' && BrowserDetect.version <= 7) goBlankPage();

function goBlankPage() {
    window.location = 'blank.aspx';
}