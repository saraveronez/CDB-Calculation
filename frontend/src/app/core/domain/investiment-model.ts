export class InvestimentModel {
  months: number;
  initialValue: number;

  constructor(months: number, initialValue: number){
    if(!months) throw new Error("Invalid months");
    if(!initialValue) throw new Error("Invalid initialValue");

    this.months = months;
    this.initialValue = initialValue;
  }
}