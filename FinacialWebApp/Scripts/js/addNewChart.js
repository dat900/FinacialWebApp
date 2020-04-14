function addNewChart(container, labels, type_money, data, type_chart, pointColor, backgroundColor) {
	var options = {
		type: type_chart,
		data: {
			labels: labels,
			datasets: [
				{
					label: type_money,
					data: data,
					borderWidth: 3,
					pointRadius: 4,
					pointBackgroundColor: backgroundColor,
					backgroundColor: pointColor
				}
			]
		}
	};
	container =  new Chart(container, options);
}
