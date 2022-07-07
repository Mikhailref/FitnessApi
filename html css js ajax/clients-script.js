console.log('hello');

document.getElementById('IDbutton').addEventListener('click',loadClients);

function loadClients()
{
    //Create XHR Object
var xhr=new XMLHttpRequest();

//1 OPEN - type, url/file, async
xhr.open('GET', 'https://localhost:7280/api/clients', true);

   //2 ONLOAD
   xhr.onload= function()
   {
   var json=xhr.responseText;
   console.log(json);
   var clients = JSON.parse(json);
   console.log(clients);
   
   var output='';	
   for(var i in clients)
   {   
    let gender;
    switch(clients[i].gender)
    {
        case 0:
            gender='uknown';
            break;
            case 1:
                gender='male';
                break;
                case 2:
                    gender="female";
                    break;
    }
  
   output+=
     '<div class="clients">'+
     '<img class="imageOfClient" src="'+clients[i].image+'" width="160" height="160" alt="logo" >'+
     '<div class="imageDescription">'+
     '<ul >'+
     '<li>ID:'+clients[i].id+'</li>'+
     '<li>'+clients[i].firstName+' '+clients[i].secondName+'</li>'+
     '<li>'+gender+'</li>'+
     '</ul>'+
     '</div>'+
     '</div>';
   }
   
   let DIVclients=document.getElementById('IDdiv');
   DIVclients.innerHTML=output;	
   
   }
         
       //3 SENDs request	
       xhr.send();	

}