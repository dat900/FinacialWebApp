function addNewChart(container, labels, type_money, data, type, pointColor, backgroundColor) {
	var options = {
		type: type,
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
	new Chart(container, options);
}
