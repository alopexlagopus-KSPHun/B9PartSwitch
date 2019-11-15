using System;
using Xunit;
using B9PartSwitch.Fishbones;
using B9PartSwitch.Fishbones.Parsers;
using B9PartSwitchTests.TestUtils.DummyTypes;

namespace B9PartSwitchTests.Fishbones.Parsers
{
    public class NodeObjectWrapperTest
    {
        [NodeObject]
        private class DummyNodeObject { }

        #region For

        [Fact]
        public void TestFor__IConfigNode()
        {
            NodeObjectWrapperIConfigNode wrapper = Assert.IsType<NodeObjectWrapperIConfigNode>(NodeObjectWrapper.For(typeof(DummyIConfigNode)));
            Assert.Equal(typeof(DummyIConfigNode), wrapper.type);
        }

        [Fact]
        public void TestFor__IContextualNode()
        {
            NodeObjectWrapperIContextualNode wrapper = Assert.IsType<NodeObjectWrapperIContextualNode>(NodeObjectWrapper.For(typeof(DummyIContextualNode)));
            Assert.Equal(typeof(DummyIContextualNode), wrapper.type);
        }

        [Fact]
        public void TestFor__ConfigNode()
        {
            Assert.IsType<NodeObjectWrapperConfigNode>(NodeObjectWrapper.For(typeof(ConfigNode)));
        }

        [Fact]
        public void TestFor__NodeObject()
        {
            NodeObjectWrapperNodeObject wrapper = Assert.IsType<NodeObjectWrapperNodeObject>(NodeObjectWrapper.For(typeof(DummyNodeObject)));
            Assert.Equal(typeof(DummyNodeObject), wrapper.type);
        }

        [Fact]
        public void TestFor__OtherType()
        {
            NotImplementedException ex = Assert.Throws<NotImplementedException>(delegate
            {
                NodeObjectWrapper.For(typeof(string));
            });

            Assert.Equal("No way to build node object wrapper for type System.String", ex.Message);
        }

        #endregion

        #region IsNodeType

        [Fact]
        public void TestIsNodeType__IConfigNode()
        {
            Assert.True(NodeObjectWrapper.IsNodeType(typeof(DummyIConfigNode)));
        }

        [Fact]
        public void TestIsNodeType__IContextualNode()
        {
            Assert.True(NodeObjectWrapper.IsNodeType(typeof(DummyIContextualNode)));
        }

        [Fact]
        public void TestIsNodeType__ConfigNode()
        {
            Assert.True(NodeObjectWrapper.IsNodeType(typeof(ConfigNode)));
        }

        [Fact]
        public void TestIsNodeType__NodeObject()
        {
            Assert.True(NodeObjectWrapper.IsNodeType(typeof(DummyNodeObject)));
        }

        [Fact]
        public void TestIsNodeType__Not()
        {
            Assert.False(NodeObjectWrapper.IsNodeType(typeof(DummyClass)));
        }

        #endregion
    }
}
