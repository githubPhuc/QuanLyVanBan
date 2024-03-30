//LoadData
function loadData(isDelete, Action, ...searchKey) {
    var data = {};
    for (var i = 0; i < searchKey.length; i++) {
        var id = searchKey[i].slice(1);
        var name = id;
        var value = $('#' + id).val();
        data[name] = value;
    }
    console.log(data)
    if (isDelete == true) {
        try {

            $.ajax({
                url: Action,
                timeout: 2000000,
                data: data,
                beforeSend: function () {
                    $(".divLoading").addClass("loading");
                },
                success: function (response) {
                    $(".divLoading").removeClass("loading");
                    $('.table-body').html(response);
                    $("#myTable").DataTable({

                        destroy: true,
                        "order": [[1, "desc"]],
                        "language": {
                            "sProcessing": "Đang xử lý...",
                            "sLengthMenu": " Hiển thị _MENU_ dữ liệu",
                            "sZeroRecords": "Không tìm thấy kết quả",
                            "sEmptyTable": "Không có dữ liệu",
                            "sInfo": "Hiển thị _START_ tới _END_ của _TOTAL_ dữ liệu",
                            "sInfoEmpty": "Hiển thị 0 tới 0 của 0 dữ liệu",
                            "sInfoFiltered": "(được lọc từ _MAX_ dữ liệu)",
                            "sInfoPostFix": "",
                            "sSearch": "Tìm kiếm:",
                            "sUrl": "",
                            "sInfoThousands": ",",
                            "sLoadingRecords": "Đang tải...",
                            "oPaginate": {
                                "sFirst": "Đầu tiên",
                                "sLast": "Cuối cùng",
                                "sNext": "Sau",
                                "sPrevious": "Trước"
                            },
                            "oAria": {
                                "sSortAscending": ":Sắp xếp thứ tự tăng dần",
                                "sSortDescending": ": Sắp xếp thứ tự giảm dần"
                            }
                        },
                        "lengthMenu": [5, 10, 25, 50, 75, 100],
                        "columnDefs": [
                            {
                                "targets": [0,],
                                orderable: false
                            },
                        ],
                        "info": false,
                        "processing": false,
                        "serverSide": false,
                        "bFilter": true,
                        "bPaginate": true,
                        "bLengthChange": true,
                        "bInfo": true,
                        "responsive": true,
                        "lengthChange": true,
                        "autoWidth": false,
                        "stateSave": true,
                        "buttons": ["copy", "csv", "excel", "pdf", "print", "colvis"],
                        "initComplete": function (oSettings) {

                        }
                    })
                },
                error: function (message) {
                    $(".divLoading").removeClass("loading");
                }
            });
        } catch (e) {

        }
    }
    else {
        //không làm gì cả
    }
}
//Load modal
function loadModal(title = "Title", action, modalParams, formData, callback) {
    var id = {}
    if (formData && formData != '') {
        if (typeof (formData) == 'object') {

            id = { ...formData }
        }
        else {
            id["Id"] = formData
       }
    }
    console.log(id)
    if (modalParams && Object.keys(modalParams).length !== 0) {
        modalParams.$myModalContent.html("");
        modalParams.$myModalTitle.html(`${title}`);
    }
    $.ajax({
        url: action,
        timeout: 2000000,
        data: id,
        beforeSend: function (xhr) {
            $(".divLoading").addClass("loading");
        },
    }).done(function (data) {
        if (modalParams && Object.keys(modalParams).length !== 0) {
            modalParams.$myModalContent.html(data);
            modalParams.$modal.modal();
        }
        if (callback) {
            callback(data,null)
        }
        $(".divLoading").removeClass("loading");

    }).fail(function (message) {
        $(".divLoading").removeClass("loading");
    });
}
//Action với callback
function ActionFunc(action, type, formData, token, callback) {
    if (type.toUpperCase() == "GET") {
        $.ajax({
            url: action,
            timeout: 2000000,
            type: `${type}`,
            data: formData,
            headers: {
                'Authorization': 'Bearer ' + token // Thêm token vào header của request
            }
        }).done(function (data) {
            console.log(data)
            if (callback) {
             callback(data, null);
            }
        }).fail(function (message) {
            $(".divLoading").removeClass("loading");
        });
    }      
    if (type.toUpperCase() == "POST") {
        $.ajax({
            url: action,
            timeout: 2000000,
            type: `${type}`,
            data: formData,
            headers: {
                'Authorization': 'Bearer ' + token // Thêm token vào header của request
            },
            beforeSend: function (xhr) {
                $(".divLoading").addClass("loading");
            },
            }).done(function (data) {
                if (data.status <= 0) {
                    callback(null, error);
                }
                else {
                    callback(data, null);

                }
            $(".divLoading").removeClass("loading");

        }).fail(function (message) {
            $(".divLoading").removeClass("loading");
        });
    }
}
//Action 
function Action(action, type, formData, paramsLoadData)
{
    if (typeof (type) != 'string') {
        console.log("Type must be string")
    }
    if (typeof (action) != 'string') {
        console.log("The params Action is not valid")
    }
    $.ajax({
        url: action,
        timeout: 2000000,
        type: `${type}`,
        data: formData,
        beforeSend: function (xhr) {
            $(".divLoading").addClass("loading");
        },
    }).done(function(data) {
        if (data.status <= 0) {
            notify(data.text, "error");
        }
        else {
            notify(data.text, "success");
            if (paramsLoadData) {
                loadData(...paramsLoadData)
            }
            
        }
        $(".divLoading").removeClass("loading");

    }).fail(function (message) {
        $(".divLoading").removeClass("loading");
    });
}
//Xuất excel
function ActionExport(action, type, formData) {
    if (typeof (type) != 'string') {
        console.log("Type must be string")
    }
    if (typeof (action) != 'string') {
        console.log("The params Action is not valid")
    }
    $.ajax({
        url: action,
        timeout: 2000000,
        type: `${type}`,
        data: formData,
        beforeSend: function (xhr) {
            $(".divLoading").addClass("loading");
        },
        success: function (result) {
            if (result.status >= 1) {
                window.location.href = result.obj;
            }
            else {
                notify(result.text, "error");
            }

            $(".divLoading").removeClass("loading");
        },
        error: function (message) {
            $(".divLoading").removeClass("loading");
        }
    });
}
//Check validate Email 
function isEmail(emailAddress) {
    const emailRegex = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
    return emailRegex.test(emailAddress);
}
//Search tiếng việt 
function removeAccents(str) {
    return str.normalize("NFD").replace(/[\u0300-\u036f]/g, "");
}
// Hàm debounce
function debounce(func, delay) {
    let timer;
    return function () {
        const context = this;
        const args = arguments;
        clearTimeout(timer);
        timer = setTimeout(() => {
            func.apply(context, args);
        }, delay);
    };
}
//Auto lấy danh sách địa điểm làm việc 
function getNameLocation(action, formData, idSelected) {
        $.ajax({
            type: "POST",
            url: action,
            data: { username: formData },
            success: function (response) {
                if (response.status == 1) {
                    $(`${idSelected}`).val(response.text);
                    $(`${idSelected}`).trigger('chosen:updated');
                }
                else {
                    $(`${idSelected}`).val('');
                    $(`${idSelected} option[value=""]`).prop('selected', true);
                    $(`${idSelected}`).trigger('chosen:updated');
                }
            },
            error: function (error) {
                notify("Đã xảy ra lỗi khi gửi dữ liệu", error);
            }
        });
}
//Zoom image 
function fadeInImage(Id) {
    $(`${Id}`).click(function () {
        var imgSrc = $(this).find("img").attr("src");
        var overlay = $("<div class='overlay'></div>");
        var img = $("<img class='enlarged-image' src='" + imgSrc + "' />");

        overlay.append(img);
        $("body").append(overlay);

        overlay.click(function () {
            overlay.remove();
        });
    });


}