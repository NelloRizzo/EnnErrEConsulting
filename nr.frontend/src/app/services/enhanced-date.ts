export const isLeapYear = (year: number): boolean => { return (year % 100 == 0 && year % 400 == 0) || (year % 100 != 0 && year % 4 == 0) }

export default class EnhancedDate {
  constructor(private _year: number, private _month: number, private _day: number) { }

  static from(date: Date) { return new EnhancedDate(date.getFullYear(), date.getMonth(), date.getDate()) }
  get day(): number { return this._day }
  get month(): number { return this._month }
  get year(): number { return this._year }
  get dayOfWeek(): number { return new Date(this._year, this._month, this._day).getDay() }

  firstDayOfMonth(): EnhancedDate { return new EnhancedDate(this._year, this._month, 1) }

  lastDayOfMonth(): EnhancedDate { return this.addMonths(1).firstDayOfMonth().addDays(-1) }

  nextDayOfWeek(dayOfWeek: number): EnhancedDate {
    const now = new Date(this._year, this._month, this._day).getDay()
    return this.addDays(now - dayOfWeek)
  }

  previousDayOfWeek(dayOfWeek: number): EnhancedDate {
    const now = new Date(this._year, this._month, this._day).getDay()
    return this.addDays(dayOfWeek == 0 ? now : dayOfWeek - now)
  }

  isPrevious(date: EnhancedDate) {
    if (this._year == date._year) {
      if (this._month == date._month) {
        return this._day < date._day
      }
      return this._month < date._month
    }
    return this._year < date._year
  }

  isNext(date: EnhancedDate) {
    if (this._year == date._year) {
      if (this._month == date._month) {
        return this._day > date._day
      }
      return this._month > date._month
    }
    return this._year > date._year
  }

  addYears(years: number): EnhancedDate { return new EnhancedDate(this._year + years, this._month, this._day) }

  addMonths(months: number): EnhancedDate {
    const result = new EnhancedDate(this._year, this._month, this._day)
    const incr = months < 0 ? -1 : 1
    months = Math.abs(months)
    while (months > 0) {
      result._month += incr
      months--
      if (result._month == 12) {
        result._month = 0
        result._year++
      }
      else if (result._month < 0) {
        result._month = 11
        result._year--
      }
    }
    return result
  }

  addDays(days: number): EnhancedDate {
    const result = new EnhancedDate(this._year, this._month, this._day)
    const montDays = [31, 28 + (isLeapYear(this._year) ? 1 : 0), 31, 30, 31, 30, 31, 31, 30, 31, 30, 31]
    const incr = days < 0 ? -1 : 1
    days = Math.abs(days)
    while (days > 0) {
      result._day += incr
      days--
      if (result._day > montDays[result._month]) {
        if (result._month == 11) {
          result._month = 0
          result._year++
        }
        else
          result._month++
        result._day = 1
      } else if (result._day < 1) {
        if (result._month == 0) {
          result._month = 11
          result._year--
        }
        else
          result._month--
        result._day = montDays[result._month]
      }
    }
    return result
  }
}

