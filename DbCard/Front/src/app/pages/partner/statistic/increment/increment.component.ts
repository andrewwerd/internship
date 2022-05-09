import {
    Component,
    ElementRef,
    Input,
    AfterViewInit,
    ViewChild,
    OnChanges,
    SimpleChanges
} from "@angular/core";

@Component({
    selector: "app-increment",
    templateUrl: "./increment.component.html",
    styleUrls: ["./increment.component.css"]
})
export class IncrementComponent implements AfterViewInit, OnChanges {
    @Input() duration: number | undefined;
    @Input() digit: number | undefined;
    @Input() steps: number | undefined;
    @ViewChild("animatedDigit") animatedDigit: ElementRef | undefined;

    animateCount() {
        if (!this.duration) {
            this.duration = 1000;
        }

        if (typeof this.digit === "number") {
            this.counterFunc(this.digit, this.duration, this.animatedDigit!);
        }
    }

    counterFunc(endValue: number, durationMs: number, element: ElementRef) {
        if (!this.steps) {
            this.steps = 12;
        }

        const stepCount = Math.abs(durationMs / this.steps);
        const valueIncrement = (endValue - 0) / stepCount;
        const sinValueIncrement = Math.PI / stepCount;

        let currentValue = 0;
        let currentSinValue = 0;

        function step() {
            currentSinValue += sinValueIncrement;
            currentValue += valueIncrement * Math.sin(currentSinValue) ** 2 * 2;

            element.nativeElement.textContent = Math.abs(Math.floor(currentValue));

            if (currentSinValue < Math.PI) {
                window.requestAnimationFrame(step);
            }
        }

        step();
    }

    ngAfterViewInit() {
        if (this.digit) {
            this.animateCount();
        }
    }

    ngOnChanges(changes: SimpleChanges) {
        if (changes["digit"]) {
            this.animateCount();
        }
    }
}
