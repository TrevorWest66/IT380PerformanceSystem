console.log("this is working");

document.getElementById("expandable").addEventListener("click", openMenu);

function openMenu() {
	document.getElementById("drop-down").classList.toggle("active");
}

//function selectedtext() {
	//var option = $("#employee option:selected").html();
	//console.log(option);

function showDiv(threadId, element) {
	document.getElementById(threadId).style.display = element ? 'block' : 'none';
	console.log("show div");
}


