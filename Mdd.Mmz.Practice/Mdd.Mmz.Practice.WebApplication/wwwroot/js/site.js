// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$(document).ready(function () {
    $('#addButton').click(() => openEdit(new Person()));
    $("#peopleTable").on("click", ".ibtnEdit", function (event) { edit(this); });
    $("#peopleTable").on("click", ".ibtnDel", function (event) { openDelete(this); });
    $("#viewButton").click(() => get());

    $('#editSaveButton').click(() => save());
    $('#editCancelButton').click(() => closeEdit());

    $('#deleteCancelButton').click(() => closeDelete());


    get();

});


function Person() {
    this.id;
    this.age;
    this.phone;
    this.name;
    this.city;
    this.country;
}


function get() {
    $.ajax({
        type: "GET",
        url: "People/Get",
        dataType: "json",
        success: (data) => {
            if (data.error) {
                error(data.message)
            }
            else {
                set(data);
            }
        }
    });
}

function set(data) {
    $("#peopleTable").find("tr:gt(0)").remove();

    data.forEach(i => addRow(i));

}

function addRow(i) {
    let newRow = $("<tr>");

    let cols = "";

    cols += '<td>' + i.id + '</td>';
    cols += '<td>' + i.age + '</td>'
    cols += '<td>' + i.phone + '</td>'
    cols += '<td>' + i.name + '</td>'
    cols += '<td>' + i.country + '</td>'
    cols += '<td>' + i.city + '</td>'

    var button1 = '<input type="button" class="ibtnEdit btn btn-dark" data=' + i.id + ' value="Edit">';
    var button2 = '<input type="button" class="ibtnDel btn btn-dark" data=' + i.id + ' value="Delete">';

    cols += '<td>' + button1 + "&nbsp" + button2 + '</td>';

    newRow.append(cols);
    $("#peopleTable").append(newRow);

}


function openEdit(person) {
    setEdit(person);

    bootstrap.Modal.getOrCreateInstance($('#editModal')).show();
}

function closeEdit() {
    bootstrap.Modal.getOrCreateInstance($('#editModal')).hide();
}


function openDelete(e) {
    let id = $(e).attr('data');


    $('#deleteSaveButton').click(() => del(id));

    bootstrap.Modal.getOrCreateInstance($('#deleteModal')).show();
}

function closeDelete() {
    bootstrap.Modal.getOrCreateInstance($('#deleteModal')).hide();
}

function openError() {
    bootstrap.Modal.getOrCreateInstance($('#errorModal')).show();
}



function setEdit(person) {
    $("input[name='id']").val(person.id);
    $("input[name='name']").val(person.name);
    $("input[name='age']").val(person.age);
    $("input[name='phone']").val(person.phone);
    $("input[name='country']").val(person.country);
    $("input[name='city']").val(person.city);
}

function save() {

    let person = new Person();

    person.id = $("input[name='id']").val();
    person.age = $("input[name='age']").val();
    person.phone = $("input[name='phone']").val();
    person.name = $("input[name='name']").val();
    person.country = $("input[name='country']").val();
    person.city = $("input[name='city']").val();

    $.ajax({
        type: "POST",
        url: "People/Save",
        dataType: "json",
        data: person,
        success: (data) => {
            if (data.error) {
                error(data.message)
            }
            else {
                closeEdit();
                get();
            }
            
        }
    });

}

function edit(e) {
    let id = $(e).attr('data');

    $.ajax({
        type: "GET",
        url: "People/GetById",
        dataType: "json",
        data: { personId: id },
        success: (data) => {
            if (data.error) {
                error(data.message)
            }
            else {
                openEdit(data);
            }
            
        }
    });
}

function del(id) {

    $.ajax({
        type: "DELETE",
        url: "People/Delete",
        dataType: "json",
        data: { id: id },
        success: (data) => {
            if (data.error ) {
                error(data.message)
            }
            else {
                closeDelete();
                get();
            }
            
        }
    });

}

function tableSearch() {
    var phrase = document.getElementById('searchText');
    var table = document.getElementById('peopleTable');
    var regPhrase = new RegExp(phrase.value, 'i');
    var flag = false;
    for (var i = 1; i < table.rows.length; i++) {
        flag = false;
        for (var j = table.rows[i].cells.length - 1; j >= 0; j--) {
            flag = regPhrase.test(table.rows[i].cells[j].innerHTML);
            if (flag) break;
        }
        if (flag) {
            table.rows[i].style.display = "";
        } else {
            table.rows[i].style.display = "none";
        }

    }
}


function error(message) {
    closeDelete();
    closeEdit();
    openError(message);
}





