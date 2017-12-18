



$(document).ready(function () {   
    $('.btnBack').click(function () {
        window.history.back();
        return false;
    })


  //  NProgress.start();

   // setTimeout(function () { NProgress.done(); }, 1500);
    
    //$('form').submit(function () {
    //    NProgress.start();
    //});

});



var _privet = _privet || {}

_privet.methods = {

    formatAMPM: function (jsonDate) {
        var date = new Date(parseInt(jsonDate.substr(6)));
        var hours = date.getHours();
        var minutes = date.getMinutes();
        var ampm = hours >= 12 ? 'pm' : 'am';
        hours = hours % 12;
        hours = hours ? hours : 12; // the hour '0' should be '12'
        minutes = minutes < 10 ? '0' + minutes : minutes;
        var strTime = hours + ':' + minutes + ' ' + ampm;
        return strTime;
    },
    loadInfoBox: function (index) {
        //var html = $.ajax({
        var url = "/Map/infoBox/" + index;
        //    async: false
        //}).responseText;

        return _privet.methods.loadHtml(url);

      //  return html;
    },
    loadPhoto:function(userid){
        //var html = $.ajax({
        var url = "/Map/getPhoto/" + userid;
        //    async: false
        //}).responseText;

        //var img = document.createElement('img');
        //img.src = html;
        //img.className = 'RoundedImg img32';
       var html =    _privet.methods.loadHtml(url)
            var img = '<img src="' + html + '" class="RoundedImg img32" alt="' + userid + '"/>'
            return img;

        
    },
    loadUserListItem:function(userid){
    
        //var html = $.ajax({
        var url = "/Map/showListitem/" + userid;
        //    async: false
        //}).responseText;
        //return html;
        return _privet.methods.loadHtml(url);
    },
    rad : function(x) {
        return x * Math.PI / 180;
    },
    loadHtml: function (url, callback) {
        var html = $.ajax({
            url: url,
            async: false
        }).responseText;
       // alert(html);
        if (callback == undefined) { return html; }
        else { callback(html); }
    },
    
    //sysncDetails: function (p1,p2, date1 , date2, placeholder, callback) {

    ////var p1 = new google.maps.LatLng(lat1, lng1);
    ////var p2 = new google.maps.LatLng(lat2, lng2);
    //    var R = 6378137; // Earth’s mean radius in meter
    //    alert('p1:' + p1 + '-p2:' + p2);
    //var dLat = _privet.methods.rad(p2.lat() - p1.lat());
    //var dLong =_privet.methods.rad(p2.lng() - p1.lng());
    //var a = Math.sin(dLat / 2) * Math.sin(dLat / 2) +
    //  Math.cos(_privet.methods.rad(p1.lat())) * Math.cos(_privet.methods.rad(p2.lat())) *
    //  Math.sin(dLong / 2) * Math.sin(dLong / 2);
    //var c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1 - a));
    //var d = R * c;
    //d = Math.round(d)

    //if (d < 1000) { $(placeholder).find('.distance').text(d + 'M'); }// returns the distance in meter
    //else { $(placeholder).find('.distance').text(String(d / 1000) + 'Km'); }
    //alert('number is :' + d + 'div:' + $(placeholder).find('.distance').html());

    //callback(placeholder);
    //},


  

}


// app name space
var _app = _app || {};


// widgets classes
_app.jsTool = {

    intDaTatable: function () {

        //  $.getScript("/_Design/js/minified/widgets/other-datatables.min.js");
        $('.table').dataTable({

            "oLanguage": {
                "sUrl": "https://cdn.datatables.net/plug-ins/1.10.16/i18n/Arabic.json"
            }

           
        });

               
            
        },
    intDatetPicker: function () {
      //  $.getScript("/_Design/js/minified/widgets/jqueryui-datepicker.min.js");
        $('.datepicker').datepicker();

        

    },
    intColorPicker: function () {
        $('.colorpicker').minicolors();
    },
    intToolTip: function () {

        $('.tooltip-button').tooltip({
            'selector': '',
            'placement': 'top',
            'container': 'body'
        });
    },


    progbar: {
    
        sart:function(){
        NProgress.start();
        },
        done: function () { NProgress.done() },
    },

    
    


}

_app.msgBox = {


    redAlert: function (txt) {

        var n = noty({
            layout: 'center',
            text: '<i class="glyph-icon icon-cog mrg5R"></i> ' + txt,
            modal: true,
            type: 'error',
            dismissQueue: true,
            theme: 'agileUI'
        });
    },

        
    msgConfirm : function (txt, yes , no) {

    var n = noty({
        layout: 'center',
        text: '<i class="glyph-icon icon-cog mrg5R"></i> ' + txt,
        modal: true,
        type: 'warning',
        theme: 'agileUI',
        buttons: [
{
    addClass: 'btn btn-primary', text: 'Ok', onClick: function ($noty) {

        yes();
    }
},
{
    addClass: 'btn btn-danger', text: 'Cancel', onClick: function ($noty) {
        $noty.close();
        no();
		        
    }
}
        ]



    });

    return false;

    }

    ,
    info: function (txt)
    {
        var n = noty({
            layout: 'center',
            text: '<i class="glyph-icon icon-cog mrg5R"></i> ' + txt,
            modal: true,
            type: 'info',
            theme: 'agileUI'
        });

    }
}





_app.gMap = {
    mapObject: Object ,
    userPath :  {
    'userid': 0,
    'path': Object,
    infobxs: [],
    },
    markers : new Array,
    userJSON: function () {
        return _app.gMap.userPath;

    },
    users:  new Array(),
    
    initializeMap: function (height, callback) {

        var mapOptions = {
            center: new google.maps.LatLng(29.200092, 29.918739),
            zoom: 6,
            mapTypeControl: false,
        };
        _app.gMap.mapObject = new google.maps.Map(document.getElementById('div_map'),
            mapOptions);
        


      //  alert('int map');
        if (height == undefined) {
          
        }
        else if (height == 0) {
              var h = $("#page-sidebar").height();
            h = h - 100;
            $("#div_map").height(h + 'px');
        }
        else {

            $("#div_map").height(height + 'px');
        }

        if (callback != undefined) {callback(); }
        
    },
    

    addPath: function (userid , d, callback) {
        


        var arr = new Array();
        _app.gMap.requestPath(userid, d, function (data) {

            arr = data;
            if (arr.length==0) { return; }
            //alert(arr);
         //   alert('in with ' + arr.length);
            var points = new Array;
            var user = new _app.gMap.userJSON();

            //   alert('user:'+ arr[0].userid +' - ' +arr.length);


            for (var i = 0; i < arr.length; i++) {
                user.userid = arr[i].userid;
                points.push(new google.maps.LatLng(
                    arr[i].lat,
                    arr[i].lng));

                _app.gMap.addMarkerpoint(arr[i], user, arr[i].color, arr.length, i);


            }
            var Path = new google.maps.Polyline({
                path: points,
                geodesic: true,
                strokeColor: arr[0].color,
                strokeOpacity: 1.0,
                strokeWeight: 2
            });

            Path.setMap(_app.gMap.mapObject);
            user.path = Path;
            $('#ShownUsers').append(_privet.methods.loadUserListItem(user.userid));




            _app.gMap.users.push({ userid: user.userid, path: user.path, infobxs: user.infobxs });

          //  alert(points.length);

            _app.jsTool.intToolTip();

            if (callback != undefined) { callback(); };


        });

        


    },

    removePath: function (uid, callback) {
        // remove the user

      //  alert('u count:' + _app.gMap.users.length);
        for (var i = _app.gMap.users.length - 1; i >= 0 ; i--) {
            if (_app.gMap.users[i].userid == uid) {
                _app.gMap.users.splice(i, 1);
            }
        }

      //  alert('u count:' + _app.gMap.users.length);

      //  alert('m count:' + _app.gMap.markers.length);
        for (var i = _app.gMap.markers.length - 1; i >= 0 ; i--) {
            if ($(_app.gMap.markers[i].getContent()).attr('personid') == uid) {
                _app.gMap.markers.splice(i, 1);
            }
        }
      //  alert('m count:' + _app.gMap.markers.length);
      
        if (callback != undefined) {

            callback();
        }
        

    }
    
    , addMarkerpoint: function (ls, u, color, count , index)
    {


        var m = new RichMarker({
            map: _app.gMap.mapObject,
            position: new google.maps.LatLng(ls.lat, ls.lng), 
            draggable: false,
            flat: true,
            anchor: RichMarkerPosition.MIDDLE,
            content: '<a title="" class="tooltip-button hover-blue btn small mico" href="#" color="'+ color +'" Personid="'+ u.userid+'"  data-original-title="' + _privet.methods.formatAMPM(ls.time) + '"><i class="glyph-icon icon-circle-o"></i></a>'
        });

        if (count - 1 == index) {
            m.setContent(
                '<a personid="' + u.userid + '">'+
                _privet.methods.loadPhoto(u.userid));
            +'</a>'
        };

        
        google.maps.event.addListener( m, 'mouseover', function () {


            _app.jsTool.intToolTip();

        });
     
        //var infowindow = new google.maps.InfoWindow({
        //   // content: _privet.methods.loadInfoBox(ls.id),
        //    maxWidth:400,
        //});


        //google.maps.event.addListener(m, 'click', function () {

        //    infowindow.setContent(_privet.methods.loadInfoBox(ls.id));
        //    infowindow.open(_app.gMap.mapObject, m);
        //    _app.jsTool.intToolTip();
        //    //  infoboxs[i].open(mapObject, marker);
        //    //  _privet.methods.showInfoBox(_app.gMap.markers[i].getTitle());
        //});
        //u.infobxs.push(infowindow);


        infoBubble = new InfoBubble({
          //  map: map,
          //  content: '<div class="mylabel">The label</div>',
            position: m.getPosition(), //new google.maps.LatLng(-32.0, 149.0),
            shadowStyle: 1,
            padding: 0,
           // backgroundColor: 'rgb(57,57,57)',
            borderRadius: 5,
            arrowSize: 10,
        //    borderWidth: 1,
            borderColor: '#2c2c2c',
            disableAutoPan: true,
            hideCloseButton: false,
            arrowPosition: 30,
          //  backgroundClassName: 'transparent',
            arrowStyle: 2
        });
        _app.gMap.markers.push(m);
        google.maps.event.addListener(m, 'click', function () {

            
           
            var i = _app.gMap.markers.indexOf(m);
            
                infoBubble.setContent(_privet.methods.loadInfoBox(ls.id));
           
            infoBubble.open(_app.gMap.mapObject, m);

        });

        google.maps.event.addListener(infoBubble, 'domready', function () {
            

            
            _
            _app.jsTool.intToolTip();
        });

        
    },

    

    centerMap: function () {


        if (_app.gMap.users.length > 0) {

            var bounds = new google.maps.LatLngBounds();

            var ic = 0
           
               // alert(_app.gMap.users[i].userid);
                for (var i = 0; i < _app.gMap.markers.length; i++) {
                    bounds.extend(_app.gMap.markers[i].getPosition());
                    
                

            }

            _app.gMap.mapObject.fitBounds(bounds);
        }
        //else {

        //    _app.gMap.mapObject.setCenter(new google.maps.LatLng(29.200092, 29.918739));
        //}

    },

    shPath: function (id, show) {
     //   alert(id);
        var m;
        if (show == true) { m = _app.gMap.mapObject; }
        else { m = null; }
        var href = document.createElement('a');
        var u;
        for (var i = 0; i < _app.gMap.users.length; i++) {
             

            if (_app.gMap.users[i].userid == id)
            {
                u = _app.gMap.users[i];
              //  alert('match wthz ' + u.userid);
                //alert('markers ' + u.markers.length)
                u.path.setMap(m);
               // alert (u.markers.length);
            }
            

        }


        for (var i = 0; i < _app.gMap.markers.length; i++) {

         //   $('#dlog').html($('#dlog').html() + u.markers[i].getContent());
            //if ($(href).attr('Perosonid') == u.userid) {
            //    u.markers[i1].setMap(m);
            //    $('#dlog').html($('dlog').html() +'found ' + i1);

            // }

            var data = $(_app.gMap.markers[i].getContent());

            var id = data.attr('personid');
           // $('#dlog').html($('#dlog').html() +'id:'+ id);
            if ( id == u.userid) {
                _app.gMap.markers[i].setMap(m);
              //  $('#dlog').html($('#dlog').html() +'userid:' + u.userid +'-'+ i );
            }

        }

    },
    requestPath: function (userid, d , done) {

        //$.getJSON("/Map/GetUserPath/" + userid + '?d=' + d, function (data) {


        //   // if (data.length > 0) { alert(data.length); return data; }
        //   // else { return null; }
        //    alert(data.length);
        //    $('#dlog').html(data);

        //    return data;
        //});

        $.ajax({
            url: "/Map/GetUserPath/" + userid + '?d=' + d,
            dataType: 'json',
            async: false, 
            success: function (data) {
                //    alert(data.length);
                 //   $('#dlog').html(data);

                    done(data);

                   // return data;
            }
        });

       

    },

    resizeMap: function () {

        var center = _app.gMap.mapObject.getCenter();
        google.maps.event.trigger(_app.gMap.mapObject, 'resize');
        //google.maps.event.trigger(map, 'resize');
        _app.gMap.mapObject.setCenter(center);

    }

  
    
}

//end widgets classes
// end name space

