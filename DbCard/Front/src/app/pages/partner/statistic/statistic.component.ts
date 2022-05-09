import { Component, OnInit } from "@angular/core";
import { ChartConfiguration, ChartData, ChartType } from 'chart.js';
import { BaseChartDirective } from 'ng2-charts';

import DataLabelsPlugin from 'chartjs-plugin-datalabels';

@Component({
  selector: 'app-statistic',
  templateUrl: './statistic.component.html',
  styleUrls: ['./statistic.component.css']
})
export class StatisticComponent implements OnInit {
  public barChartOptions: ChartConfiguration['options'] = {
    responsive: true,
    // We use these empty structures as placeholders for dynamic theming.
    scales: {
      x: {},
      y: {
        min: 10
      }
    },
    plugins: {
      legend: {
        display: true,
      },
      datalabels: {
        anchor: 'end',
        align: 'end'
      }
    }
  };
  public barChartType: ChartType = 'bar';
  public barChartPlugins = [
    DataLabelsPlugin
  ];

  public barChartData: ChartData<'bar'> = {
    labels: ['Понедельник', 'Вторник', 'Среда', 'Четверг', 'Пятница', 'Суботта', 'Воскресенье'],
    datasets: [
      { data: [65, 59, 80, 81, 56, 55, 40], label: 'Средние посещения' }
    ]
  };

  public genderChartData: ChartData<'bar'> = {
    labels: [''],
    datasets: [
      { data: [120521.245], label: 'Женщины' },
      { data: [90521.245], label: 'Мужчины' }
    ]
  };

  customerChartData: ChartData<'doughnut'> = {
    labels: ['Customers'],
    datasets: [
      { data: [350] }
    ]
  };

  weeklyUsageData: ChartData<'doughnut'> = {
    labels: ['Customers'],
    datasets: [
      { data: [350] }
    ]
  };

  public radarChartOptions: ChartConfiguration['options'] = {
    responsive: true
  };
  public radarChartLabels: string[] = ['10-20', '20-30', '30-40', '50-60', '60-70'];

  public radarChartData: ChartData<'radar'> = {
    labels: this.radarChartLabels,
    datasets: [
      {
        data: [12360.26, 36264.98, 86942, 50474.85, 25000.4],
        label: 'Траты по возрасту',
        backgroundColor: 'rgba(148,159,177,0.2)',
        borderColor: 'rgba(148,159,177,1)',
        pointBackgroundColor: 'rgba(148,159,177,1)',
        pointBorderColor: '#fff',
        pointHoverBackgroundColor: '#fff',
        pointHoverBorderColor: 'rgba(148,159,177,0.8)',
        fill: 'origin',
      }
    ]
  };
  public radarChartType: ChartType = 'radar';

  ngOnInit(): void {

  }

}