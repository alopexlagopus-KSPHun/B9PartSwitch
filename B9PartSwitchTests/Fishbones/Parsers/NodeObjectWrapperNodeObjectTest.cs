using System;
using Xunit;
using B9PartSwitch.Fishbones;
using B9PartSwitch.Fishbones.Parsers;
using B9PartSwitchTests.TestUtils;

namespace B9PartSwitchTests.Fishbones.Parsers
{
    public class NodeObjectWrapperNodeObjectTest
    {
        [NodeObject]
        private class DummyNodeObject
        {
            [NodeData(persistent = true)]
            public string value;
        }

        private readonly NodeObjectWrapperNodeObject wrapper = new NodeObjectWrapperNodeObject(typeof(DummyNodeObject));

        #region Constructor

        [Fact]
        public void TestConstructor()
        {
            Assert.Equal(typeof(DummyNodeObject), wrapper.type);
        }

        [Fact]
        public void TestConstructor__NullType()
        {
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(delegate
            {
                new NodeObjectWrapperNodeObject(null);
            });

            Assert.Equal("type", ex.ParamName);
        }

        #endregion

        #region Load

        [Fact]
        public void TestLoad()
        {
            DummyNodeObject obj = new DummyNodeObject();
            object objRef = obj;

            ConfigNode node = new TestConfigNode
            {
                { "value", "blah" },
            };

            wrapper.Load(ref objRef, node, Exemplars.LoadPrefabContext);

            Assert.Same(obj, objRef);
            Assert.Equal("blah", obj.value);
        }

        [Fact]
        public void TestLoad__NullObj()
        {
            object obj = null;

            ConfigNode node = new TestConfigNode
            {
                { "value", "blah" },
            };

            wrapper.Load(ref obj, node, Exemplars.LoadPrefabContext);

            DummyNodeObject newObj = Assert.IsType<DummyNodeObject>(obj);
            Assert.Equal("blah", newObj.value);
        }

        [Fact]
        public void TestLoad__NullNode()
        {
            object obj = null;

            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(delegate
            {
                wrapper.Load(ref obj, null, Exemplars.LoadPrefabContext);
            });

            Assert.Equal("node", ex.ParamName);
        }

        #endregion

        #region Save

        [Fact]
        public void TestSave()
        {
            DummyNodeObject obj = new DummyNodeObject()
            {
                value = "stuff",
            };

            ConfigNode node = wrapper.Save(obj, Exemplars.SaveContext);

            Assert.Single(node.values);
            Assert.Equal("value", node.values[0].name);
            Assert.Equal("stuff", node.values[0].value);
            Assert.Empty(node.nodes);
        }

        [Fact]
        public void TestSave__NullObj()
        {
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(delegate
            {
                wrapper.Save(null, Exemplars.LoadPrefabContext);
            });

            Assert.Equal("obj", ex.ParamName);
        }

        [Fact]
        public void TestSave__NullContext()
        {
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(delegate
            {
                wrapper.Save(new DummyNodeObject(), null);
            });

            Assert.Equal("context", ex.ParamName);
        }

        #endregion
    }
}
