google.charts.load('current', { packages: ['corechart'] });
google.charts.setOnLoadCallback(drawChart);

function drawChart() {
	let currentBudget = parseInt(document.getElementById('current-budget').innerHTML);
	let usedBudget = parseInt(document.getElementById('used-budget').innerHTML);
	let unusedBudget = currentBudget - usedBudget;
	if (unusedBudget < 0) {
		unusedBudget = 0;
	}

	var data = new google.visualization.DataTable();
	data.addColumn('string', 'label')
	data.addColumn('number', 'Budget')
	data.addRows([
		['Used', usedBudget],
		['Unused', unusedBudget]
	]);

	var options = {
		'title': 'Budget Utilization',
		'titleTextStyle': { 'fontSize': '16'},
		'width': '400',
		'height': '300',
		'colors': ['maroon', '#757575']
	};

	var chart = new google.visualization.PieChart(document.getElementById('budget-chart'));
	chart.draw(data, options);
}