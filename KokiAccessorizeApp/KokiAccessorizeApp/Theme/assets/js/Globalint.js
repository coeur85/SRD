
    $(document).ready(function () {

       $('.dataTable').DataTable();


//  $('form').validate();

      

        //$.validator.setDefaults({
        //    highlight: function (element) {
        //        $(element).closest('.form-group').addClass('has-error');
        //    },
        //    unhighlight: function (element) {
        //        $(element).closest('.form-group').removeClass('has-error');
        //    },
        //    errorElement: 'span',
        //    errorClass: 'help-block',
        //    errorPlacement: function (error, element) {
        //        if (element.parent('.input-group').length) {
        //            error.insertAfter(element.parent());
        //        } else {
        //            error.insertAfter(element);
        //        }
        //    }
        //});



     



    $('.alert-dismissible').each(function (index) {
           

      

           $(this).fadeOut(5000);




    });



    jQuery(".standardSelect").chosen({
        disable_search_threshold: 4,
        no_results_text: "Oops, nothing found!",
        width: "100%"
    });
       


});



function get(controllerName, methodName, param, success, error) {

    

    var url = document.location.origin + '/api/' + controllerName + '/' + methodName;
   

    $.ajax({
        url: url,
        type: 'POST',
        data: JSON.stringify(param),
        contentType: "application/json;charset=utf-8",
        success: function (data) {
           
            success(data);
        },
        error: function (x, y, z) {
            
            error(x, y, z);
        }
    });


}



