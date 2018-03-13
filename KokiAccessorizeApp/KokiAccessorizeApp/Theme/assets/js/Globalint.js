
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
       


    $('.standardSelect').on('change', function (evt, params) {
        var selectedValue = params.selected;
        console.log(selectedValue);
        $('#ProductID').val(selectedValue);



        var prm = { 'ProductID': selectedValue };
        get('ProductsOrders', 'ProductInfo', prm, function (data) {
            $('#Price').val(data['Price']);
            $('#CosePrice').val(data['CostPrice']);
            $('#Qantaty').val(1);
         //   alert(JSON.stringify(data));

        }
            , function () { alert('smothing went wrong !'); })



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



