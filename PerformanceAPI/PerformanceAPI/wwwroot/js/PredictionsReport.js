var ctx = document.getElementById('SummaryBudgetChart').getContext('2d');
var SummaryBudgetChart = new Chart(ctx, {
    type: 'pie',
    data: {
        labels: ['Unused', 'Used'],
        datasets: [{
            label: 'Budget Used',
            data: [20, 80],
            backgroundColor: [
                '#8E8C8C',
                '#FF2015'
            ],
            borderColor: [
                '#FFFFFF',
                '#FFFFFF'
            ],
            borderWidth: 2
        }]
    },
    options: {
        title: {
            display: true,
            text: 'Budget Used'
        },
        responsive: true,
        maintainAspectRatio: false,
    }
});