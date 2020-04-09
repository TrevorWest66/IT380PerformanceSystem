var ctx = document.getElementById('ActualBudgetChart').getContext('2d');
var actualsChart = new Chart(ctx, {
    type: 'pie',
    data: {
        labels: ['Unused', 'Used'],
        datasets: [{
            label: 'Budget Used',
            data: [25, 75],
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