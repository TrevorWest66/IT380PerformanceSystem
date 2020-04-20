google.charts.load('current', { packages: ['corechart'] });
google.charts.setOnLoadCallback(drawChart);

function drawChart() {
	let completedEmployees = parseInt(document.getElementById('employees-done').innerHTML);
	let totalEmployees = parseInt(document.getElementById('employees-total').innerHTML);
	let notCompletedEmployees = totalEmployees - completedEmployees;

	var data = new google.visualization.DataTable();
	data.addColumn('string', 'label')
	data.addColumn('number', 'Employees')
	data.addRows([
		['Completed', completedEmployees],
		['Not Completed', notCompletedEmployees]
	]);

	var options = {
		'title': 'Projections Progress',
		'titleTextStyle': { 'fontSize': '16' },
		'width': '400',
		'height': '300',
		'colors': ['#CD1C1B', '#757575']
	};

	var chart = new google.visualization.PieChart(document.getElementById('projections-chart'));
	chart.draw(data, options);
}