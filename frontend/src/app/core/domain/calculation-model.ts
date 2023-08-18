export class CalculationModel {
  netValueTotal: number;
  grossValueTotal: number;
  netProfit : number;
  grossProfit: number;
  taxes : number;

  constructor(netValueTotal: number, grossValueTotal: number,  netProfit : number, grossProfit: number, taxes : number){
    this.netValueTotal = netValueTotal;
    this.grossValueTotal= grossValueTotal;
    this.netProfit= netProfit;
    this.grossProfit = grossProfit;
    this.taxes = taxes;
  }
}