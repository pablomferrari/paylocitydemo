import { Dependent } from "../employee-detail/components/dependent/models";

export interface Employee {
    id: number;
    firstName: string;
    lastName: string;
    salary: number;
    dependents: Dependent[]
}