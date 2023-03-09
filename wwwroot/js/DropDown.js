//$(document).ready(function(){
//    $('#country').attr('disabled', true);
//    $('#state').attr('disabled', true);
//    $('#city').attr('disabled', true);
//    LoadCountries(); 
//});

//function LoadCountries() {
//    $('#country').empty();

//    $.ajax({
//        url: '/User/GetCountries',
//        success: function (response) {
//            if (response != null && response != undefined && response.length > 0) {
//                $('#country').attr('disabled', false);
//                $('#country').append('<option>--select Country--</option>');
//                $('#state').append('<option>--select State--</option>');
//                $('#city').append('<option>--select City--</option>');
//                $.each(response, function (i, data) {
//                    $(#country).append('<option value=' + data.id + '>' + data.name + '</option>');
//                });
//            }
//            else{
//                $('#country').attr('#disabled', true);
//                $('#state').attr('disabled', true);
//                $('"city').attr('disabled', true);
//                $('#country').append('<option>--Countries not avaiable--</option>');
//                $('#country').append('<option>--State not avaiable--</option>');
//                $('#country').append('<option>--Cities not avaiable--</option>');

//            }

//                },
//        error: function (error) {

//        }
//        })
//}