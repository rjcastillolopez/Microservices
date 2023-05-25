import { Score } from './score.model';

export interface Course {
    _id: string;    
    name: string;
    code: string;
    scores: Score[];
}