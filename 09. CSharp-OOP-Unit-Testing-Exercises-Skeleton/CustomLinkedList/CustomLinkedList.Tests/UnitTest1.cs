using CustomLinkedList;
using NUnit.Framework;
using System;
using System.Linq;
using System.Reflection;

namespace Tests
{
    public class Tests
    {
        private DynamicList<int> intList;
        private DynamicList<string> stringList;

        [SetUp]
        public void Setup()
        {
            this.intList = new DynamicList<int>();
            this.stringList = new DynamicList<string>();
            for (int i = 5; i < 10; i++)
            {
                intList.Add(i);
            }
        }

        [Test]
        public void ListNodeConstructorGettingElementShouldSetCorrectly()
        {
            string currentItem = "Mimi";
            Type type = typeof(DynamicList<string>).GetNestedTypes(BindingFlags.NonPublic | BindingFlags.Instance).FirstOrDefault(x => x.Name == "ListNode");
            Type constructed = type.MakeGenericType(typeof(string));
            var instance = Activator.CreateInstance(constructed, new object[] { currentItem });

            var element = instance.GetType().GetProperty("Element").GetValue(instance, null);
            var nextNode = instance.GetType().GetProperty("NextNode").GetValue(instance, null);

            Assert.AreEqual("Mimi", element);
            Assert.AreEqual(null, nextNode);
        }
        [Test]
        public void ListNodeConstructorGettingElementAndListNodeShouldSetCorrectly()
        {
            string firstInstanceItem = "Mimi";
            string secondInstanceItem = "Desi";

            Type type = typeof(DynamicList<int>).GetNestedTypes(BindingFlags.NonPublic | BindingFlags.Instance).FirstOrDefault(x => x.Name == "ListNode");
            Type constructed = type.MakeGenericType(typeof(string));
            var instance = Activator.CreateInstance(constructed, new object[] { firstInstanceItem });
            var secondConstructorInstance = Activator.CreateInstance(constructed, new object[] { secondInstanceItem, instance });

            var element = secondConstructorInstance.GetType().GetProperty("Element").GetValue(secondConstructorInstance, null);
            var prevNodeElement = instance.GetType().GetProperty("Element").GetValue(instance, null);
            // Previous next node and current element
            var prevNextNode = instance.GetType().GetProperty("NextNode").GetValue(instance, null);

            Assert.AreEqual("Desi", element);
            Assert.AreEqual("Mimi", prevNodeElement);
            Assert.AreEqual("Desi", prevNextNode.GetType().GetProperty("Element").GetValue(prevNextNode, null));
        }
        [Test]
        public void DynamicListConstructorShouldSetCorrectly()
        {
            var head = stringList.GetType().GetField("head", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(stringList);
            var tail = stringList.GetType().GetField("tail", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(stringList);

            Assert.AreEqual(0, this.stringList.Count);
            Assert.IsNull(head);
            Assert.IsNull(tail);
        }
        [Test]
        public void CountShoudGetCorrectly()
        {
            Assert.AreEqual(5, intList.Count);
        }
        [Test]
        [TestCase(5)]
        [TestCase(9)]

        public void IndexOfMethodShouldReturnTheRightIndexOfAnExistingItem(int num)
        {

            Assert.AreEqual(num - 5, intList.IndexOf(num));

        }
        [Test]
        public void IndexOfMethodShouldReturnMinus1ForNotExistingItem()
        {
            Assert.AreEqual(-1, intList.IndexOf(10));
        }
        [Test]
        public void AddMethodShouldAddCorrectly()
        {

            var head = intList.GetType().GetField("head", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(intList);
            var tail = intList.GetType().GetField("tail", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(intList);

            Assert.AreEqual(5, head.GetType().GetProperty("Element").GetValue(head));
            Assert.AreEqual(9, tail.GetType().GetProperty("Element").GetValue(tail));
            Assert.AreEqual(5, this.intList.Count);
        }

        [Test]
        public void ElementIndexerGetsCorrectly()
        {
            Assert.AreEqual(8, intList[3]);
        }
        [Test]
        public void ElementIndexerSetsCorrectly()
        {
            intList[1] = 15;

            Assert.AreEqual(15, intList[1]);
        }
        [Test]
        public void ElementIndexerGetterThrowsExceptionForInvalidIndex()
        {
            int num = 0;
            Assert.Throws<ArgumentOutOfRangeException>(() => num = intList[5], "Invalid index: " + 5);
        }
        [Test]
        public void ElementIndexerSetterThrowsExceptionForInvalidIndex()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => intList[-1] = 15, "Invalid index: " + -1);
        }
        [Test]
        public void RemoveAtIndexMethodShouldRemoveTheCorrectItem()
        {
            int removedItem = intList.RemoveAt(3);

            Assert.AreEqual(8, removedItem);
            Assert.AreEqual(4, intList.Count);
            Assert.That(!intList.Contains(8));
        }
        [Test]
        public void RemoveAtIndexMethodShouldThrowExceptionForInvalidIndex()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => intList.RemoveAt(10));
        }
        [Test]
        public void RemoveMethodShouldRemoveTheCorrectItem()
        {
            int index = intList.Remove(6);

            Assert.AreEqual(1, index);
            Assert.AreEqual(4, intList.Count);
            Assert.That(!intList.Contains(6));
        }
        [Test]
        public void RemoveMethodShouldReturnMinus1ForInvalidItem()
        {
            Assert.AreEqual(-1, intList.Remove(15));
        }
        [Test]
        public void ContainsMethodShouldReturnTrueForExistingItem()
        {
            Assert.AreEqual(true, intList.Contains(7));
        }
        [Test]
        public void ContainsMethodShouldReturnFalse()
        {
            Assert.AreEqual(false, intList.Contains(10));
        }

    }
}