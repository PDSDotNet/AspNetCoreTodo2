$(function () {
    $('.DatePickerScript').datepicker({
        format: 'dd/mm/yyyy',
        todayHighlight: true,
        todayBtn: true,
        daysOfWeekHighlighted: '1,2,3,4,5',
        weekStart: '1',
        autoclose: true,
        startDate: '28/10/2018',
        language: "es"
    });
})