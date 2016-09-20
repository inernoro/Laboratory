(function ($) {
    //备份jquery的ajax方法  
    var ajax = $.ajax;
    //重写jquery的ajax方法  
    $.ajax = function (option) {
        //console.log({ Url: option.url, Data: option.data, Type: option.type });
        var opt = $.extend(option, {
            url: "/Network/Call",
            data: {
                obj: { Url: option.url, Data: option.type.toLocaleLowerCase() === "post" ? option.data : JSON.stringify(option.data), Type: option.type }
            },
            type: "post",
            dataType: "json",
            contentType: "application/x-www-form-urlencoded"
        });
        ajax(opt);
    };
})(jQuery);