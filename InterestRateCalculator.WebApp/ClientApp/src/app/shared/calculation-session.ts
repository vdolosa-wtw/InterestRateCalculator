import { CalculationResult } from "./calculation-result";

export interface CalculationSession {
  id: string,
  value: number,
  years: number,
  dateTime: Date,
  userId: string,
  results: CalculationResult
}
