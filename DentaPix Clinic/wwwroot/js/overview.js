// Bar chart


new Chart(document.getElementById("bar-chart"), {
    type: 'bar',
    data: {
        labels: ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"],
        datasets: [

            {
                label: "Total Patient",
                backgroundColor: ["#3e95cd", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#3e95cd", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#e8c3b9", "#c45850" ],
                data: [0, 0, 0, 0, 0, 0, 10, 0, 0, 0, 0, 0 ]
            }
        ]
    },
    options: {
        legend: { display: false },
        title: {
            display: true,
            text: 'Total Patients For Year 2022'
        }
    }
});

//// Bar chart
//new Chart(document.getElementById("bar-chart1"), {
//    type: 'bar',
//    data: {
//        labels: ["Africa", "Asia", "Europe", "Latin America", "North America"],
//        datasets: [
//            {
//                label: "Population (millions)",
//                backgroundColor: ["#3e95cd", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850"],
//                data: [2478, 5267, 734, 784, 433]
//            }
//        ]
//    },
//    options: {
//        legend: { display: false },
//        title: {
//            display: true,
//            text: 'Predicted world population (millions) in 2050'
//        }
//    }
//});