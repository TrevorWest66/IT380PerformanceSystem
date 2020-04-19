console.log("this is working");

document.getElementById("expandable").addEventListener("click", openMenu);

function openMenu() {
	document.getElementById("drop-down").classList.toggle("active");
}
