function checkInput(e) {
	if ($('#date_picker').val() == "" || $('#money').val() == "" || $('#note').val() == "")
	{
		alert("Please enter all infomation")
		e.preventDefault(e)
	}
}
window.onkeypress = function (event) {
	if (event.keyCode == 112) {
		$("#refresh").click();
	}
	else if (event.keyCode == 113) {
		$("#outcomebymonth").click();
	}
	else if (event.keyCode == 114) {
		$("#outcomebyyear").click();
	}
	else if (event.keyCode == 115) {
		$("#outcomebyyear").click();
	}
}