console.log("hello");

function LoadEmployees()
{	
    //Create XHR Object	
    var xhr= new XMLHttpRequest();	
        
    //1 OPEN - type, url/file, async	
    xhr.open('GET','https://localhost:7280/api/employees', true);	
        
   //2 ONLOAD
xhr.onload= function()
{
var json=xhr.responseText;
var employees = JSON.parse(json);
console.log(employees);

var output='';	
for(var i in employees)
{   
output+=
  '<div class="employees">'+
  '<img class="imageOfEmployee" src="'+employees[i].image+'" width="260" height="260" >'+
  '<div class="imageDescription">'+
  '<ul >'+
  '<li>ID:'+employees[i].id+'</li>'+
  '<li>'+employees[i].firstName+' '+employees[i].secondName+'</li>'+
  '<li>'+employees[i].department+' </li>'+
  '</ul>'+
  '</div>'+
  '</div>';
}

let DIVemployees=document.getElementById('IDdiv');
DIVemployees.innerHTML=output;	

}
    
    
    //3 SENDs request	
    xhr.send();	
}



