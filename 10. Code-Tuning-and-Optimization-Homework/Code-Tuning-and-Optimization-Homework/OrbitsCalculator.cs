﻿namespace SolarSystem
{
    using System;
    using System.ComponentModel;
    using System.Windows.Threading;

    internal class OrbitsCalculator : INotifyPropertyChanged
    {
        private const double EarthYear = 365.25;

        private const double EarthRotationPeriod = 1.0;

        private const double SunRotationPeriod = 25.0;

        private const double TwoPi = Math.PI * 2;

        private double _daysPerSecond = 2;

        private double _startDays;

        private DateTime _startTime;

        private DispatcherTimer _timer;

        public OrbitsCalculator()
        {
            this.EarthOrbitPositionX = this.EarthOrbitRadius;
            this.DaysPerSecond = 2;
        }

        public double DaysPerSecond
        {
            get
            {
                return this._daysPerSecond;
            }

            set
            {
                this._daysPerSecond = value;
                this.Update("DaysPerSecond");
            }
        }

        public double EarthOrbitRadius
        {
            get
            {
                return 40;
            }

            set
            {
            }
        }

        public double Days { get; set; }

        public double EarthRotationAngle { get; set; }

        public double SunRotationAngle { get; set; }

        public double EarthOrbitPositionX { get; set; }

        public double EarthOrbitPositionY { get; set; }

        public double EarthOrbitPositionZ { get; set; }

        public bool ReverseTime { get; set; }

        public bool Paused { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void StartTimer()
        {
            this._startTime = DateTime.Now;
            this._timer = new DispatcherTimer();
            this._timer.Interval = TimeSpan.FromMilliseconds(10);
            this._timer.Tick += this.OnTimerTick;
            this._timer.Start();
        }

        private void StopTimer()
        {
            this._timer.Stop();
            this._timer.Tick -= this.OnTimerTick;
            this._timer = null;
        }

        public void Pause(bool doPause)
        {
            if (doPause)
            {
                this.StopTimer();
            }
            else
            {
                this.StartTimer();
            }
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            var now = DateTime.Now;
            this.Days += (now - this._startTime).TotalMilliseconds * this.DaysPerSecond / 1000.0
                         * (this.ReverseTime ? -1 : 1);
            this._startTime = now;
            this.Update("Days");
            this.OnTimeChanged();
        }

        private void OnTimeChanged()
        {
            this.EarthPosition();
            this.EarthRotation();
            this.SunRotation();
        }

        private void EarthPosition()
        {
            double angle = 2 * Math.PI * this.Days / EarthYear;
            this.EarthOrbitPositionX = this.EarthOrbitRadius * Math.Cos(angle);
            this.EarthOrbitPositionY = this.EarthOrbitRadius * Math.Sin(angle);
            this.Update("EarthOrbitPositionX");
            this.Update("EarthOrbitPositionY");
        }

        private void EarthRotation()
        {
            for (decimal step = 0; step <= 360; step += 0.00005m)
            {
                this.EarthRotationAngle = ((double)step) * this.Days / EarthRotationPeriod;
            }

            //this.EarthRotationAngle = 360 * this.Days / EarthRotationPeriod;
            this.Update("EarthRotationAngle");
        }

        private void SunRotation()
        {
            this.SunRotationAngle = 360 * this.Days / SunRotationPeriod;
            this.Update("SunRotationAngle");
        }

        private void Update(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                var args = new PropertyChangedEventArgs(propertyName);
                this.PropertyChanged(this, args);
            }
        }
    }
}