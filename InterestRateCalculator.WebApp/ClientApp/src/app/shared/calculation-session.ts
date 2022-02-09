import { CalculationResult } from "./calculation-result";

export interface CalculationSession {
  id: string,
  dateTime: Date,
  userId: string,
  results: CalculationResult
}
