﻿using ReduxNET.Actions;
using ReduxNET.Posts;
using System.Collections.Immutable;

namespace Redux
{
    internal class PostsReducer
    {
        internal static PostsState Reduce(PostsState state, IAction action)
        {
            switch(action)
            {
                case FetchPosts _:
                    return state.With(Loading: true);

                case PostsFetched result:
                    return state.With(Loading: false, Posts: ImmutableList.CreateRange(result.Posts), Error: string.Empty);

                case PostsFetchFailed error:
                    return state.With(Loading: false, Posts: ImmutableList<Post>.Empty, Error: error.Message);

                case PostSelected post:
                    return state.With(SelectedPostId: post.Id);

                case SearchPosts search:
                    return state.With(SearchQuery: search.Query);
            }

            return state;
        }
    }
}