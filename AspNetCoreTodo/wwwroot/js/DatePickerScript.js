$(function () {
    $('.DatePickerScript').datetimepicker({
        format: 'dd/mm/yyyy hh:ii',
        todayHighlight: true,
        todayBtn: true,
        weekStart: '1',
        autoclose: true,
        startDate: '-0d',
        language: "es"
    });
})