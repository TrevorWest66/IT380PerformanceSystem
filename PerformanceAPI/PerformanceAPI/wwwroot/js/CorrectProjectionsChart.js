google.charts.load('current', { packages: ['corechart'] });
google.charts.setOnLoadCallback(drawChart);

function drawChart() {
	let completedEmployees = parseInt(document.getElementById('employees-correct-projections').innerHTML);
	let totalEmployees = parseInt(document.getElementById('employees-actuals-done').innerHTML);
	let notCompletedEmployees = totalEmployees - completedEmployees;

	var data = new google.visualization.DataTable();
	data.addColumn('string', 'label')
	data.addColumn('number', 'Projections')
	data.addRows([
		['Actualized', completedEmployees],
		['Not Actualized', notCompletedEmployees]
	]);

	var options = {
		'title': 'Actualized Projections',
		'titleTextStyle': { 'fontSize': '16' },
		'width': '400',
		'height': '300',
		'colors': ['maroon', '#757575']
	};

	var chart = new google.visualization.PieChart(document.getElementById('projections-actualized-chart'));
	chart.draw(data, options);
}