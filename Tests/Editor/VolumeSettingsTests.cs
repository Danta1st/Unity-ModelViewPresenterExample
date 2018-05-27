using System;
using NUnit.Framework;
using UnityEngine;

namespace MVP.Tests.Editor
{
    [TestFixture]
    public class VolumeSettingsTests
    {
        private class MockVolumeSettingsView : IVolumeSettingsView
        {
            public event Action OnIncreaseVolumeButtonClicked;
            public event Action OnDecreaseVolumeButtonClicked;

            public int Volume;
            public void OnVolumeChanged(int volume)
            {
                Volume = volume;
            }

            public Color VolumeColor;
            public void SetVolumeColoring(Color color)
            {
                VolumeColor = color;
            }
        }

        private MockVolumeSettingsView mockView;
        private IVolumeModel model;
        private VolumeSettingsPresenter presenter;
        
        
        [SetUp]
        public void Setup()
        {
            mockView = new MockVolumeSettingsView();
            model = new VolumeModel();
            presenter = new VolumeSettingsPresenter(mockView, model);
        }

        [TearDown]
        public void Teardown()
        {
            mockView = null;
            model = null;
            presenter = null;
        }

        [Test]
        public void VolumeModel_OnVolumeChanged_TriggersEvent()
        {
            model.OnVolumeChanged += i =>
            {
                Assert.AreEqual(3, i);
            };
            model.Volume = 3;
        }

        [TestCase(11, ExpectedResult = 10)]
        [TestCase(-1, ExpectedResult = 0)]
        [TestCase(5, ExpectedResult = 5)]
        public int VolumeModel_SetVolume_IsClamped(int target)
        {
            model.Volume = target;
            return model.Volume;
        }

        [Test]
        public void Presenter_OnVolumeChanged_UpdatesView()
        {
            model.Volume = 1;
            Assert.AreEqual(1, mockView.Volume);
        }
        
        [Test]
        public void Presenter_OnVolumeChanged_SetColorRed_If6OrHigher()
        {
            model.Volume = 6;
            Assert.AreEqual(Color.red, mockView.VolumeColor);
        }
        
        [Test]
        public void Presenter_OnVolumeChange_SetColorBlack_If5OrLower()
        {
            model.Volume = 5;
            Assert.AreEqual(Color.black, mockView.VolumeColor);
        }
    }
}
